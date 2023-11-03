using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform player;

    private int enemiesSpawned = 0;

    void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    IEnumerator SpawnEnemies()
    {
        while (true)
        {
            yield return new WaitForSeconds(3); // Cambia este valor al intervalo que desees entre spawneos.

            // Verifica si ya se han eliminado 4 enemigos
            if (enemiesSpawned < 4)
            {
                for (int i = 0; i < 2; i++)
                {
                    Instantiate(enemyPrefab, transform.position, Quaternion.identity);
                    enemiesSpawned++;
                }
            }
        }
    }
}