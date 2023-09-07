using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HordaSpawner : MonoBehaviour
{
    public GameObject hordaPrefab;
    public float velocidadHorda = 2.0f;
    public float frecuenciaSpawn = 3.0f;
    private float tiempoUltimoSpawn = 0.0f;

    void Update()
    {
        // Calcula el tiempo desde el último spawn
        float tiempoActual = Time.time;
        if (tiempoActual - tiempoUltimoSpawn >= frecuenciaSpawn)
        {
            // Realiza el spawn de la horda
            SpawnHorda();
            tiempoUltimoSpawn = tiempoActual;
        }
    }

    void SpawnHorda()
    {
        // Encuentra al jugador
        GameObject jugador = GameObject.FindGameObjectWithTag("Player");

        if (jugador != null)
        {
            // Crea una nueva instancia de la horda y la configura
            GameObject nuevaHorda = Instantiate(hordaPrefab);
            nuevaHorda.transform.position = transform.position;

            // Configura la velocidad de movimiento de la horda y el jugador como objetivo
            HordaController hordaController = nuevaHorda.GetComponent<HordaController>();
            if (hordaController != null)
            {
                hordaController.ConfigurarHorda(velocidadHorda, jugador.transform);
            }
            else
            {
                Debug.LogError("El prefab de la horda no tiene un componente HordaController adjunto.");
            }
        }
        else
        {
            Debug.LogError("No se pudo encontrar al jugador. Asegúrate de que el jugador tenga la etiqueta 'Player'.");
        }
    }
}