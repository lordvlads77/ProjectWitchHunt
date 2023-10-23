using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public Transform player;
    public GameObject[] levelPrefabs;
    public float spawnDistance = default;

    private List<GameObject> spawnedLevels = new List<GameObject>();
    private float playerLastPosition;

    void Start()
    {
        playerLastPosition = player.position.z;
        InitializeLevel();
    }

    void Update()
    {
        float playerPosition = player.position.z;

        if (playerPosition > playerLastPosition - spawnDistance)
        {
            SpawnLevel();
            playerLastPosition = playerPosition;
        }
    }

    void InitializeLevel()
    {
        for (int i = 0; i < 4; i++)
        {
            SpawnLevel();
        }
    }

    void SpawnLevel()
    {
        int randomLevelIndex = Random.Range(0, levelPrefabs.Length);
        GameObject newLevel = Instantiate(levelPrefabs[randomLevelIndex], transform.forward * playerLastPosition, Quaternion.identity);
        spawnedLevels.Add(newLevel);

        if (spawnedLevels.Count > 4)
        {
            Destroy(spawnedLevels[0]);
            spawnedLevels.RemoveAt(0);
        }
    }
}
