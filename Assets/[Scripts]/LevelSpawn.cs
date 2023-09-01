using Unity.VisualScripting;
using UnityEngine;

public class LevelSpawn : MonoBehaviour
{
    [SerializeField] private GameObject _LeveltoSpawn = default;
    [SerializeField] private GameObject _LeveltoSpawn1 = default;
    [SerializeField] private GameObject _LeveltoSpawn2 = default;
    [SerializeField] private GameObject _LeveltoSpawn3 = default;
    [SerializeField] private int _randAgregator = 5;
    private string randMsg = " The Value is ";
    void Start()
    {
        Instantiate(_LeveltoSpawn);
    }
    
    void OnTriggerEnter()
    {
        var rando = Random.Range(0, 3) * _randAgregator;
        print(randMsg + rando);
        if (rando == 0)
        {
            Instantiate(_LeveltoSpawn);
        }
        if (rando == 1)
        {
            Instantiate(_LeveltoSpawn1);
        }
        if (rando == 2)
        {
            Instantiate(_LeveltoSpawn2);
        }
        if (rando == 3)
        {
            Instantiate(_LeveltoSpawn3);
        }
    }
    //TODO: Make the missing prefabs, and test the Script.
}
