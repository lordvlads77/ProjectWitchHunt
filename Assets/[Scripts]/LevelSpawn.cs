using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using Quaternion = System.Numerics.Quaternion;
using Random = UnityEngine.Random;

public class LevelSpawn : MonoBehaviour
{
    [FormerlySerializedAs("_levelPrefab")] [SerializeField] private GameObject _vesselPrefab;
    [SerializeField] private List<GameObject> _levelPrefabs = new List<GameObject>();
    [SerializeField] private int _selectedRandomLevel;
    [SerializeField] private GameObject _gameObject;

    void Start()
    {
        foreach (GameObject OBJ in GameObject.FindGameObjectsWithTag("LevelToSpawn"))
        {
            _levelPrefabs.Add(OBJ);
        }
        //Instantiate(_levelPrefabs[randomLevel], transform.position, Quaternion.identity);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (_levelPrefabs.Count > 0)
            {
                spawnNewLevel();
            }
        }
    }

    public void spawnNewLevel()
    {
        _selectedRandomLevel = Random.Range(0, _levelPrefabs.Count);
        _levelPrefabs.Remove(_gameObject);
        instantiateNewLevel(_gameObject);
        //_levelPrefabs.RemoveAt(_selectedRandomLevel);
    }
    
    public void instantiateNewLevel(GameObject _gameObject)
    {
        Instantiate(_levelPrefabs[Index.Start], _gameObject.transform.position, _gameObject.transform.rotation);
    }
    //TODO: Test the New Version of the Script else click on the following link and start adapting from there
    // https://stackoverflow.com/questions/65713832/spawning-random-gameobject-in-map-no-repetitions
    
}
