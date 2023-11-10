using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingPowerUp : MonoBehaviour
{
    [SerializeField]
    public int healingAmount = 20; // Cantidad de curaci�n que proporciona este power-up

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Objeto colisionado: " + other.gameObject.name);
        if (other.CompareTag("Player"))
        {
            Debug.Log("Colisi�n con el jugador detectada");

            HealthBarScript healthBar = other.GetComponentInChildren<HealthBarScript>();
            if (healthBar != null)
            {
                healthBar.UpdateHealth(healthBar.currentHealth + healingAmount);
                Debug.Log("Vida actual del jugador: " + healthBar.currentHealth);
            }

            Destroy(gameObject);
            Debug.Log("Poci�n destruida");
        }
    }

    // Si quieres mantener la funci�n HealPlayer, puedes llamarla desde OnTriggerEnter
    void HealPlayer(GameObject player)
    {
        // Aqu� podr�as acceder al script de salud del jugador o su sistema de salud para curarlo
        // Ejemplo b�sico:
        HealthBarScript health = player.GetComponent<HealthBarScript>();
        if (health != null)
        {
            health.UpdateHealth(health.currentHealth + healingAmount);
        }
    }
}