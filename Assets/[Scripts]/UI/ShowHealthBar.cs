using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowHealthBar : MonoBehaviour
{
    public static ShowHealthBar Instance
    {
        get; private set;
    }
    [SerializeField] private float _maxHealth = default;
    [SerializeField] private UIHealthBar _healthBar;
    [SerializeField] private float _currentHealth;
    private void Awake()
    {
        Instance = this;
        if(Instance != this)
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
        _currentHealth -= dmgAmount;
        _healthBar.UpdateHealthBar(_maxHealth, _currentHealth);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Dmg(10f);
    }
}
