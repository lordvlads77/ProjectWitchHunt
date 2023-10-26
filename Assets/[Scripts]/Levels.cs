using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Levels : MonoBehaviour
{
    public List<GameObject> availableLevels = new List<GameObject>();
    private List<GameObject> instantiatedLevels = new List<GameObject>();

    public Transform spawnPoint; // The position where levels will be instantiated

    private GameObject currentLevel;

    public Vector3 _originalPos;
    public Transform playerPosition;

    private void Awake()
    {
        _originalPos = playerPosition.position;
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

        // Instantiate the selected level at the spawnPoint
        if (currentLevel != null)
        {
            currentLevel.SetActive(false); // Deactivate the previous level
        }

        currentLevel = Instantiate(randomLevelPrefab, spawnPoint.position, spawnPoint.rotation);

        // Remove the selected level from availableLevels
        availableLevels.RemoveAt(randomIndex);

        // Add the instantiated level to the list of instantiated levels
        instantiatedLevels.Add(currentLevel);
    }

    private void OnTriggerEnter(Collider other)
    {
        InstantiateRandomLevel();
        playerPosition.transform.position = _originalPos;
        // if (other.CompareTag("Player"))
        // {
        //     InstantiateRandomLevel();
        // }
    }
}
