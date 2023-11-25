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
    private bool _itemDropped = false; // Nueva bandera para verificar si el objeto ya se soltó
    [SerializeField] private Animator animator;
    [SerializeField] private EnemyBehaviour _enemyBehaviour;
    [SerializeField] private GameObject itemToDrop; // Objeto que el enemigo soltará al morir

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
        if (!_isDead)
        {
            // Ejecutar la animación de muerte si es necesario
            if (animator != null)
            {
                StartCoroutine(PigDeathAnim());
            }

            // Desactivar el objeto o realizar otras acciones para indicar que el objeto ha muerto
            _isDead = true;

            // Llama al método EnemigoEliminado del GameManager
            GameManager.Instance.EnemigoEliminado();

            // Suelta el objeto al morir si no se ha soltado antes
            if (!_itemDropped)
            {
                DropItem();
                _itemDropped = true; // Marcar que el objeto ya se soltó
            }

            /*gameObject.SetActive(false);*/ // Desactivar el objeto, por ejemplo
        }
    }

    private void DropItem()
    {
        if (itemToDrop != null)
        {
            // Ajusta el valor de "alturaSuelo" según sea necesario
            float alturaSuelo = 0.7f; // por ejemplo, 0.1 unidades por encima del suelo

            Vector3 spawnPosition = new Vector3(transform.position.x, alturaSuelo, transform.position.z);
            Instantiate(itemToDrop, spawnPosition, Quaternion.identity);
        }
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