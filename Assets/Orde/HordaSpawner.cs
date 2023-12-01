using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HordaSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] enemigosPrefabs;

    [SerializeField]
    private Transform puntoSpawn; // El punto desde el cual aparecer�n los enemigos.

    [SerializeField]
    private int cantidadMaximaEnemigos = 5; // N�mero m�ximo de enemigos a spawnear.

    [SerializeField]
    private float velocidadEnemigo = 5.0f; // Velocidad de los enemigos.

    private int enemigosSpawned = 0; // Lleva un registro de enemigos spawneados.

    private bool spawnerActivo = true; // Controla si el spawner est� activo o no.

    void Start()
    {
        // Genera varios enemigos en un bucle for
        for (int i = 0; i < cantidadMaximaEnemigos; i++)
        {
            SpawnEnemigoAleatorio();
        }
    }

    void SpawnEnemigoAleatorio()
    {
        if (enemigosPrefabs.Length == 0 || enemigosSpawned >= cantidadMaximaEnemigos || !spawnerActivo)
        {
            // Si ya hemos spawnado la cantidad m�xima de enemigos o el spawner no est� activo, detenemos el proceso.
            return;
        }

        int indiceAleatorio = Random.Range(0, enemigosPrefabs.Length);

        // Use el puntoSpawn como la posici�n de aparici�n.
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