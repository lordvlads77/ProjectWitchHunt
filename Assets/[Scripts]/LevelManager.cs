using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class LevelManager : MonoBehaviour
{
    public List<GameObject> availableLevels = new List<GameObject>();
    private List<GameObject> instantiatedLevels = new List<GameObject>();

    public Transform spawnPoint; // The position where levels will be instantiated

    private GameObject currentLevel; // The level that the player is currently on
    [FormerlySerializedAs("ogPosition")] public Vector3 ogPlayerPosition;
    public Transform playerPosition;

    private void Awake()
    {
        ogPlayerPosition = playerPosition.position;
    }

    private void Start()
    {
        // Ensure there are available levels to instantiate
        if (availableLevels.Count == 0)
        {
            Debug.LogError("No available levels to instantiate. Add levels to the 'availableLevels' list in the Inspector.");
            return;
        }

        // Instantiate the first random level
        InstantiateRandomLevel();
    }

    private void InstantiateRandomLevel()
    {
        // Check if we've used all available levels
        if (availableLevels.Count == 0)
        {
            Debug.LogWarning("All available levels have been used. Resetting the list.");
            availableLevels.AddRange(instantiatedLevels);
            instantiatedLevels.Clear();
        }

        // Randomly select a level from availableLevels
        int randomIndex = Random.Range(0, availableLevels.Count);
        GameObject randomLevelPrefab = availableLevels[randomIndex];

        if (currentLevel != null)
        {
            currentLevel.SetActive(false);
        }

        // Instantiate the selected level at the spawnPoint
        currentLevel = Instantiate(randomLevelPrefab, spawnPoint.position, randomLevelPrefab.transform.rotation);
        //GameObject instantiatedLevel = Instantiate(randomLevelPrefab, spawnPoint.position, randomLevelPrefab.transform.rotation);

        // Remove the selected level from availableLevels
        availableLevels.RemoveAt(randomIndex);

        // Add the instantiated level to the list of instantiated levels
        instantiatedLevels.Add(currentLevel);
    }
    
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Player entered the trigger");
        InstantiateRandomLevel();
        playerPosition.transform.position = ogPlayerPosition;
    }
}
