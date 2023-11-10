using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarScript : MonoBehaviour
{
    [SerializeField]
    public float maxHealth = 100f; // Salud máxima del jugador
    [SerializeField]
    public float currentHealth; // Salud actual del jugador
    [SerializeField]
    private Image lifeBar; // Referencia a la imagen de la barra de vida
    private void Start()
    {
        lifeBar = GetComponent<Image>();
        currentHealth = maxHealth;
        UpdateHealthBar();
    }
    public void UpdateHealth(float newHealth)
    {
        currentHealth = Mathf.Clamp(newHealth, 0f, maxHealth);
        UpdateHealthBar(); // <-- Llamada a UpdateHealthBar
    }
    private void UpdateHealthBar()
    {
        float fillAmount = currentHealth / maxHealth;
        lifeBar.fillAmount = fillAmount; // <-- Esta línea arroja la excepción
    }
}