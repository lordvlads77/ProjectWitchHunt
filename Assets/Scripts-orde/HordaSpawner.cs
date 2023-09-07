using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HordaSpawner : MonoBehaviour
{
    public GameObject[] enemigosPrefabs; // Arreglo de Prefabs de enemigos
    public float intervaloSpawn = 3.0f; // Intervalo entre spawns
    private int indiceEnemigoActual = 0;
    public float velocidadEnemigo = 5f;

    void Start()
    {
        // Inicia el proceso de spawn
        InvokeRepeating("SpawnEnemigoAleatorio", 0f, intervaloSpawn);
    }

    void SpawnEnemigoAleatorio()
    {
        // Asegúrate de que tengas al menos un enemigo configurado
        if (enemigosPrefabs.Length == 0)
        {
            Debug.LogError("No se han configurado enemigos en el arreglo de Prefabs.");
            return;
        }

        // Genera un índice aleatorio para seleccionar el enemigo
        int indiceAleatorio = Random.Range(0, enemigosPrefabs.Length);

        // Instancia el enemigo aleatorio en la posición del spawner
        GameObject nuevoEnemigo = Instantiate(enemigosPrefabs[indiceAleatorio], transform.position, Quaternion.identity);

        // Configura el HordaController o cualquier otro componente necesario para el enemigo aquí
        HordaController hordaController = nuevoEnemigo.GetComponent<HordaController>();
        if (hordaController != null)
        {
            hordaController.ConfigurarHorda(GameObject.FindGameObjectWithTag("Player").transform, velocidadEnemigo);
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