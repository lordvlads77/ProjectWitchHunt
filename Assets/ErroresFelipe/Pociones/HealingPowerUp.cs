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
            Debug.Log("Colision con el jugador detectada");
            VidaGato vidaGato = other.GetComponentInChildren<VidaGato>();
            if (vidaGato != null)
            {
                //healthBar.UpdateHealth(healthBar.vidaGato.vida + healingAmount);
                //healthBar.UpdateHealth(healthBar.currentHealth + healingAmount);
                vidaGato.UpdateHealth(vidaGato.vida + healingAmount);
                Debug.Log("Vida actual del jugador: " + vidaGato.vida);
                ParticleController.Instance.SpwnHealingParticle();
                AudioController.Instance.PlayHealingSFX();
            }

            Destroy(gameObject);
            Debug.Log("Pocion destruida");
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