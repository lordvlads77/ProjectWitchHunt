using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedPowerUp : MonoBehaviour
{
    [SerializeField]
    private float speedMultiplier = 2f; // Multiplicador de velocidad

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player triggered the potion.");
            AudioController.Instance.PlayPotionUseSFX();
            SpeedUpPlayer(other.gameObject);
            Destroy(gameObject);
        }
    }

    void SpeedUpPlayer(GameObject player)
    {
        PlayerMovv playerMovement = player.GetComponent<PlayerMovv>();

        if (playerMovement != null)
        {
            StartCoroutine(ResetSpeed(playerMovement));
        }
    }

    System.Collections.IEnumerator ResetSpeed(PlayerMovv playerMovement)
    {
        Debug.Log("Speed increased.");

        // Aplica el multiplicador de velocidad temporalmente
        playerMovement.ApplySpeedMultiplier(speedMultiplier);

        // Espera 2 segundos
        yield return new WaitForSeconds(2f);

        // Restaura el multiplicador de velocidad original
        playerMovement.ResetSpeedMultiplier();

        Debug.Log("Speed reset.");
    }
}