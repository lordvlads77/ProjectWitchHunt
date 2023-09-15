using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HordaSpawner : MonoBehaviour
{
    public GameObject[] enemigosPrefabs; // Arreglo de Prefabs de enemigos
    public float intervaloSpawn = 3.0f; // Intervalo entre spawns
    private int indiceEnemigoActual = 0; // Índice del enemigo actual
    private float tiempoUltimoSpawn = 0.0f; // Tiempo del último spawn
    private int velocidadEnemigo = 5;

    void Start()
    {
        // Inicializa el spawn del primer enemigo
        SpawnSiguienteEnemigo();
    }

    void Update()
    {
        // Verifica si ha pasado el tiempo suficiente para spawnear el siguiente enemigo
        float tiempoActual = Time.time;
        if (tiempoActual - tiempoUltimoSpawn >= intervaloSpawn)
        {
            // Realiza el spawn del siguiente enemigo
            SpawnSiguienteEnemigo();
            tiempoUltimoSpawn = tiempoActual;
        }
    }

    void SpawnSiguienteEnemigo()
    {
        // Asegúrate de que tengas al menos un enemigo configurado
        if (enemigosPrefabs.Length == 0)
        {
            Debug.LogError("No se han configurado enemigos en el arreglo de Prefabs.");
            return;
        }

        // Instancia el siguiente enemigo en el ciclo
        GameObject nuevoEnemigo = Instantiate(enemigosPrefabs[indiceEnemigoActual], transform.position, Quaternion.identity);

        // Configura el HordaController para que siga al jugador
        HordaController hordaController = nuevoEnemigo.GetComponent<HordaController>();
        if (hordaController != null)
        {
            GameObject jugador = GameObject.FindGameObjectWithTag("Player");
            if (jugador != null)
            {
                hordaController.ConfigurarHorda(jugador.transform, velocidadEnemigo);
            }
            else
            {
                Debug.LogError("No se pudo encontrar al jugador. Asegúrate de que el jugador tenga la etiqueta 'Player'.");
            }
        }
        else
        {
            Debug.LogError("El prefab de la horda no tiene un componente HordaController adjunto.");
        }

        // Incrementa el índice para el siguiente enemigo
        indiceEnemigoActual++;

        // Si llegamos al último enemigo, reiniciamos el ciclo
        if (indiceEnemigoActual >= enemigosPrefabs.Length)
        {
            indiceEnemigoActual = 0;
        }
    }
}