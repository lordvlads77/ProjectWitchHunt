using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    
    [SerializeField] private GameObject _enemy;
    [SerializeField] private GameObject _enemy2;
    [SerializeField] private GameObject _enemy3;
    private void Awake()
    {
        Instance = this;
        if (Instance != this)
        {
            Destroy(gameObject);
        }
    }
    

    private void Start()
    {
        // Time.timeScale = 0;
        _enemy.SetActive(false);
        _enemy2.SetActive(false);
        _enemy3.SetActive(false);
    }
    
}
