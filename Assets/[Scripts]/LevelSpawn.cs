 using Unity.VisualScripting;
using UnityEngine;

public class LevelSpawn : MonoBehaviour
{
    [SerializeField] private GameObject[] _levelPrefabs;
    void Start()
    {
        int randomLevel = Random.Range(0, _levelPrefabs.Length);
        Instantiate(_levelPrefabs[randomLevel], transform.position, Quaternion.identity);
    }
    void Update()
    {
        
    }
    //TODO: Test the New Version of the Script else click on the following link and start adapting from there
    // https://stackoverflow.com/questions/65713832/spawning-random-gameobject-in-map-no-repetitions
    
}
