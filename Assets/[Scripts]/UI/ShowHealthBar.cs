using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowHealthBar : MonoBehaviour
{
    public static ShowHealthBar Instance { get; private set; }

    [SerializeField] private float _maxHealth = default;
    [SerializeField] private UIHealthBar _healthBar;
    [SerializeField] private float _currentHealth;
    private bool _isDead = false;
    public Animator anim = default;
    public Animator anim1 = default;
    public Animator anim2 = default;

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
            Destroy(gameObject);
        }
    }

    private void Die()
    {
        // Ejecutar la animación de muerte si es necesario
        Animator anim = GetComponent<Animator>();
        if (anim != null)
        {
            AnimationController.Instance.EnemyPigDeath(anim); // El nombre "Die" es el nombre del trigger en el Animator
            AnimationController.Instance.EnemyFoxDeath(anim1); // El nombre "Die" es el nombre del trigger en el Animator
            AnimationController.Instance.EnemyTurkeyDeath(anim2);
            Destroy(gameObject);// El nombre "Die" es el nombre del trigger en el Animator
        }

        // Desactivar el objeto o realizar otras acciones para indicar que el objeto ha muerto
        _isDead = true;
        gameObject.SetActive(false); // Desactivar el objeto, por ejemplo
    }

    private void OnCollisionEnter(Collision collision)
    {
        Dmg(10f);
    }
}