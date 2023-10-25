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
    private int currentIndex = -1;

    public Transform spawnPoint; // The position where levels will be instantiated
    private GameObject currentLevel; // The level that the player is currently on
    private GameObject previousLevel; // The level that the player was previously on
    
    [Header("Player Pos Reset")]
    [FormerlySerializedAs("ogPosition")] public Vector3 ogPlayerPosition;
    public Transform playerPosition;

    private void Awake()
    {
        ogPlayerPosition = playerPosition.position;
    }

    private void Start()
    {
        if (availableLevels.Count == 0)
        {
            Debug.LogError("No available levels to instantiate. Add levels to the 'availableLevels' list in the Inspector.");
            return;
        }

        // Initialize by activating the first level
        if (currentIndex == -1)
        {
            InstantiateRandomLevel1();
        }
    } 
    
    private void InstantiateRandomLevel1()
    {
        // Check if we've used all available levels
        if (availableLevels.Count == 0)
        {
            Debug.LogWarning("All available levels have been used. Resetting the list.");
            availableLevels.AddRange(instantiatedLevels);
            instantiatedLevels.Clear();
            currentIndex = -1; // Reset current level index
        }

        // Increment the current level index
        currentIndex = (currentIndex + 1) % availableLevels.Count;

        // Activate the next level
        if (currentIndex >= 0 && currentIndex < instantiatedLevels.Count)
        {
            instantiatedLevels[currentIndex].SetActive(true);
        }
        else
        {
            // Instantiate the selected level at the spawnPoint
            GameObject randomLevelPrefab = availableLevels[currentIndex];
            GameObject instantiatedLevel = Instantiate(randomLevelPrefab, spawnPoint.position, randomLevelPrefab.transform.rotation);

            // Add the instantiated level to the list of instantiated levels
            instantiatedLevels.Add(instantiatedLevel);
        }

        // Deactivate the previously activated level
        if (currentIndex > 0)
        {
            instantiatedLevels[currentIndex - 1].SetActive(false);
        }
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

        currentLevel = Instantiate(randomLevelPrefab, spawnPoint.position, randomLevelPrefab.transform.rotation);

        // Remove the selected level from availableLevels
        availableLevels.RemoveAt(randomIndex);

        // Add the instantiated level to the list of instantiated levels
        instantiatedLevels.Add(currentLevel);
    }
    
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Player entered the trigger");
        InstantiateRandomLevel1();
        playerPosition.transform.position = ogPlayerPosition;
        if (instantiatedLevels[5].activeInHierarchy)
        {
            instantiatedLevels[5].SetActive(false);
            InstantiateRandomLevel1();
        }
    }
}
