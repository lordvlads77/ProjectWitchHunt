using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class LevelController : MonoBehaviour
{
    [Header("Lists of Levels")]
    [SerializeField] private List<GameObject> availableLevels = new List<GameObject>();
    [SerializeField] private List<GameObject> instantiatedLevels = new List<GameObject>();


    [SerializeField] private Transform spawnPoint; // Where the levels will be spawned
    private string _errorLevelNotAvailable = "No levels available to spawn. Add levels to the availableLevels list.";
    private string _errorNoSpawnPoint = "No spawn point set. Please set a spawn point.";
    private string _warningAllLevelsUsed = "All available levels have been used. Resetting the list of available levels.";
    private GameObject _currentLevel = default;

    void Start()
    {
        //Ensure there are available levels to spawn
        if (availableLevels.Count == 0)
        {
            Debug.LogError(_errorLevelNotAvailable);
            return;
        }
        // Instantiate the first random level
        InstantiateRandomLevel();
    }
    
    private void InstantiateRandomLevel()
    {
        if (availableLevels.Count == 0)
        {
            Debug.LogWarning(_warningAllLevelsUsed);
            availableLevels.AddRange(instantiatedLevels);
            instantiatedLevels.Clear();
        }
        //Randomly select a level from the available levels
        int randomIndex = Random.Range(0, availableLevels.Count);
        GameObject randomLevelPrefab = availableLevels[randomIndex];
        if (_currentLevel != null)
        {
            Destroy(_currentLevel);
        }
        
        // Instatiate the selected level at the spawn point
        GameObject instantiatedLevel = Instantiate(randomLevelPrefab, spawnPoint.position , Quaternion.identity);
        
        // Remove the selected level from the availablelevels
        availableLevels.RemoveAt(randomIndex);
        
        // Add the instantiated level to the list of instantiated levels
        instantiatedLevels.Add(instantiatedLevel);
        
        //Set the currentLevel reference to the instantiated level
        _currentLevel = instantiatedLevel;
        
    }
    
    // Add a OnCollisionEnter method if the collision logic is not already present
    private void OnCollisionEnter(Collision collision)
    {
        // Check if the collision is with the object that should trigger level instantiation
        if (collision.gameObject.CompareTag("TriggerLevel"))
        {
            InstantiateRandomLevel();
        }
    }
}
