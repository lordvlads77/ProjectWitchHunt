using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HordaSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] enemigosPrefabs;

    [SerializeField]
    private float intervaloSpawn = 3.0f;

    [SerializeField]
    private float radioSpawn = 10.0f;

    [SerializeField]
    private int velocidadEnemigo = 5;


    void Start()
    {
        // Inicia el proceso de spawn
        InvokeRepeating("SpawnEnemigoAleatorio", 0f, intervaloSpawn);
    }

    void SpawnEnemigoAleatorio()
    {
        if (enemigosPrefabs.Length == 0)
        {
            Debug.LogError("No se han configurado enemigos en el arreglo de Prefabs.");
            return;
        }

        GameObject jugador = GameObject.FindGameObjectWithTag("Player");
        if (jugador != null)
        {
            float anguloAleatorio = Random.Range(0f, Mathf.PI * 2f);

            float xPos = Mathf.Cos(anguloAleatorio) * radioSpawn + jugador.transform.position.x;
            float zPos = Mathf.Sin(anguloAleatorio) * radioSpawn + jugador.transform.position.z;

            int indiceAleatorio = Random.Range(0, enemigosPrefabs.Length);

            GameObject nuevoEnemigo = Instantiate(enemigosPrefabs[indiceAleatorio], new Vector3(xPos, jugador.transform.position.y, zPos), Quaternion.identity);
            HordaController hordaController = nuevoEnemigo.GetComponent<HordaController>();
            if (hordaController != null)
            {
                hordaController.ConfigurarHorda(jugador.transform, velocidadEnemigo);
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