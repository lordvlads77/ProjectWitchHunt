using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HordaSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] enemigosPrefabs;

    [SerializeField]
    private Transform puntoSpawn; // El punto desde el cual aparecerán los enemigos.

    [SerializeField]
    private int cantidadObjetivoEnemigos = 3; // Número objetivo de enemigos a spawnear.

    [SerializeField]
    private float velocidadEnemigo = 5.0f; // Velocidad de los enemigos.

    private int enemigosSpawned = 0; // Lleva un registro de enemigos spawneados.

    private bool spawnerActivo = true; // Controla si el spawner está activo o no.

    void Start()
    {
        SpawnEnemigos();
    }

    void SpawnEnemigos()
    {
        while (enemigosSpawned < cantidadObjetivoEnemigos)
        {
            SpawnEnemigoAleatorio();
        }
    }

    void SpawnEnemigoAleatorio()
    {
        if (enemigosPrefabs.Length == 0 || !spawnerActivo)
        {
            // Si no hay enemigos configurados o el spawner no está activo, detenemos el proceso.
            return;
        }

        int indiceAleatorio = Random.Range(0, enemigosPrefabs.Length);

        // Use el puntoSpawn como la posición de aparición.
        GameObject nuevoEnemigo = Instantiate(enemigosPrefabs[indiceAleatorio], puntoSpawn.position, Quaternion.identity);
        HordaController hordaController = nuevoEnemigo.GetComponent<HordaController>();
        if (hordaController != null)
        {
            // Configura la velocidad y el objetivo del enemigo.
            hordaController.ConfigurarHorda(GameObject.FindGameObjectWithTag("Player").transform, velocidadEnemigo);

            enemigosSpawned++; // Incrementa el contador de enemigos spawneados.
        }
        else
        {
            Debug.LogError("El prefab de la horda no tiene un componente HordaController adjunto.");
        }
    }
}