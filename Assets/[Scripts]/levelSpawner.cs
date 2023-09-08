using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelSpawner : MonoBehaviour
{
    [SerializeField] private int [] arrayIndex = new int[]{0,1,2,3};
    [SerializeField] private List<int> _levelList = new List<int>();
    [SerializeField] private GameObject _LeveltoSpawn = default;
    [SerializeField] private GameObject _LeveltoSpawn1 = default;
    [SerializeField] private GameObject _LeveltoSpawn2 = default;
    [SerializeField] private GameObject _LeveltoSpawn3 = default;
    [SerializeField] private GameObject _leveltoSpawn4 = default;
    [SerializeField] private Transform _levelSpawnTransform = default;
    [SerializeField] private Transform _levelSpawnTransform1 = default;
    [SerializeField] private Transform _levelSpawnTransform2 = default;
    [SerializeField] private Transform _levelSpawnTransform3 = default;

    void Start()
    {
        _levelList.AddRange(arrayIndex);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //getUniqueRandomNum();
            Debug.Log(getUniqueRandomNum());
            if (getUniqueRandomNum() <=1)
            {
                Instantiate(_LeveltoSpawn, _levelSpawnTransform.position, _levelSpawnTransform.rotation);
            }
            if (getUniqueRandomNum() <= 2)
            {
                Instantiate(_LeveltoSpawn1, _levelSpawnTransform1.position, _levelSpawnTransform1.rotation);
            }
            if (getUniqueRandomNum()<= 3)
            {
                Instantiate(_LeveltoSpawn2, _levelSpawnTransform2.position, _levelSpawnTransform2.rotation);
            }
            if (getUniqueRandomNum() <= 4)
            {
                Instantiate(_LeveltoSpawn3, _levelSpawnTransform3.position, _levelSpawnTransform3.rotation);
            }
            if (getUniqueRandomNum() <= 5)
            {
                Instantiate(_leveltoSpawn4);
            }


        }
    }

    public int getUniqueRandomNum()
    {
        int rand = Random.Range(0, _levelList.Count);
        int value = _levelList[rand];
        _levelList.RemoveAt(rand);
        return value;
    }

    /*public void reAddLeveltoIndex()
    {
        _levelList.AddRange(arrayIndex);
    }*/
    //For the next Parcial
    
}
