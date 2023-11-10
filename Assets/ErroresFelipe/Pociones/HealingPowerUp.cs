using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingPowerUp : MonoBehaviour
{
    [SerializeField]
    public int healingAmount = 20; // Cantidad de curación que proporciona este power-up

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Objeto colisionado: " + other.gameObject.name);
        if (other.CompareTag("Player"))
        {
            Debug.Log("Colisión con el jugador detectada");

            HealthBarScript healthBar = other.GetComponentInChildren<HealthBarScript>();
            if (healthBar != null)
            {
                healthBar.UpdateHealth(healthBar.currentHealth + healingAmount);
                Debug.Log("Vida actual del jugador: " + healthBar.currentHealth);
            }

            Destroy(gameObject);
            Debug.Log("Poción destruida");
        }
    }

    // Si quieres mantener la función HealPlayer, puedes llamarla desde OnTriggerEnter
    void HealPlayer(GameObject player)
    {
        // Aquí podrías acceder al script de salud del jugador o su sistema de salud para curarlo
        // Ejemplo básico:
        HealthBarScript health = player.GetComponent<HealthBarScript>();
        if (health != null)
        {
            health.UpdateHealth(health.currentHealth + healingAmount);
        }
    }
}