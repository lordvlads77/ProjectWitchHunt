using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowHealthBar : MonoBehaviour
{
    public static ShowHealthBar Instance { get; private set; }

    [SerializeField] private float _maxHealth = default;
    [SerializeField] public UIHealthBar _healthBar;
    [SerializeField] private float _currentHealth;
    private bool _isDead = false;
    [SerializeField] private Animator animator;
    [SerializeField] private EnemyBehaviour _enemyBehaviour;

    private void Awake()
    {
        Instance = this;
        if (Instance != this)
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        _currentHealth = _maxHealth;
       // _healthBar = GetComponentInChildren<UIHealthBar>();
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
            StartCoroutine(PigDeathAnim());
        }
        
        ParticleController.Instance.SpawnDeathVFXPig();
        AudioController.Instance.PlayDeathSFX();

        // Desactivar el objeto o realizar otras acciones para indicar que el objeto ha muerto
        _isDead = true;
        /*gameObject.SetActive(false);*/ // Desactivar el objeto, por ejemplo
    }
    
    private void OnTriggerEnter(Collider other)
    {
        Dmg(10f);
    }

    private IEnumerator PigDeathAnim()
    {
        _enemyBehaviour.enabled = false;
        AnimationController.Instance.EnemyPigDeath(animator);
        yield return new WaitForSeconds(5f);
        CoinManager.GetCoinManager().AddCoin();
        Destroy(gameObject);
    }
}