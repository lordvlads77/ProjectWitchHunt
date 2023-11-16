using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurkeyShowHealthBar : MonoBehaviour
{
    [SerializeField] private float _maxHealth = default;
    [SerializeField] private UIHealthBar _healthBar;
    [SerializeField] private float _currentHealth;
    private bool _isDead = false;
    [SerializeField] private Animator animator;
    [SerializeField] private EnemyBehaviour _enemyBehaviour;
    
    private void Start()
    {
        _currentHealth = _maxHealth;
        _healthBar = GetComponentInChildren<UIHealthBar>();
    }

    public void Dmg(float dmgAmount)
    {
        if (!_isDead)
        {
            _currentHealth -= dmgAmount;
            _healthBar.UpdateHealthBar(_maxHealth, _currentHealth);
           
        }
        if (_currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        // Ejecutar la animación de muerte si es necesario
        if (animator != null)
        {
            StartCoroutine(TurkeyDeathAnim());
        }

        // Desactivar el objeto o realizar otras acciones para indicar que el objeto ha muerto
        _isDead = true;
        /*gameObject.SetActive(false);*/ // Desactivar el objeto, por ejemplo
    }
    
    private void OnTriggerEnter(Collider other)
    {
        Dmg(10f);
    }
    
    private IEnumerator TurkeyDeathAnim()
    {
        _enemyBehaviour.enabled = false;
        AnimationController.Instance.EnemyTurkeyDeath(animator);
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }
}
