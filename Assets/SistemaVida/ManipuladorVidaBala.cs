using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ManipuladorVidaBala : MonoBehaviour
{
    VidaGato playervida;
    public int cantidad;
    public float damageTime;
    float currentDamageTime;
    public int puntosGanados = 100; // Cantidad de puntos ganados al eliminar un enemigo
    public TextMeshProUGUI textoPuntuacion; // Asigna este campo en el Inspector

    private int puntaje = 0; // Variable local para mantener el puntaje del jugador

    void Start()
    {
        playervida = GameObject.FindWithTag("Enemigo").GetComponent<VidaGato>();
        if (textoPuntuacion != null)
        {
            textoPuntuacion.text = "Puntuación: " + puntaje.ToString();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemigo")
        {
            Debug.Log("Colisión con el enemigo.");
            currentDamageTime += Time.deltaTime;
            if (currentDamageTime > damageTime)
            {
                playervida.vida += cantidad;
                currentDamageTime = 0.0f;

                if (playervida.vida <= 0)
                {
                    SumarPuntos();
                    EliminarEnemigo(other.gameObject);
                }
            }
        }
    }

    void SumarPuntos()
    {
        puntaje += puntosGanados;
        if (textoPuntuacion != null)
        {
            textoPuntuacion.text = "Puntuación: " + puntaje.ToString();
        }
    }

    void EliminarEnemigo(GameObject enemy)
    {
        // Realiza aquí cualquier acción adicional antes de destruir al enemigo, como efectos visuales.
        Destroy(enemy);
    }
}