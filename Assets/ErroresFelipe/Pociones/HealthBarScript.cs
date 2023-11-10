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
    private Image healthBarImage; // Referencia a la imagen de la barra de vida
    private void Start()
    {
        healthBarImage = GetComponent<Image>();
        currentHealth = maxHealth;
        UpdateHealthBar();
    }
    public void UpdateHealth(float newHealth)
    {
        currentHealth = Mathf.Clamp(newHealth, 0f, maxHealth);
        UpdateHealthBar();
    }
    private void UpdateHealthBar()
    {
        float fillAmount = currentHealth / maxHealth;
        healthBarImage.fillAmount = fillAmount;
    }
}