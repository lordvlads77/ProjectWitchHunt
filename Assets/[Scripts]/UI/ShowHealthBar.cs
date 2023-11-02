using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowHealthBar : MonoBehaviour
{
    [SerializeField] private float _maxHealth = default;
    [SerializeField] private UIHealthBar _healthBar;
    [SerializeField] private float _currentHealth;

    private void Start()
    {
        _currentHealth = _maxHealth;
        _healthBar = GetComponentInChildren<UIHealthBar>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            Dmg(10f);
        }
    }

    private void Dmg(float dmgAmount)
    {
        _currentHealth -= dmgAmount;
        _healthBar.UpdateHealthBar(_maxHealth, _currentHealth);
    }
}
