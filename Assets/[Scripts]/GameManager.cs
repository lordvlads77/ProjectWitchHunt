using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [SerializeField] public GameObject _enemy;
    [SerializeField] public GameObject _enemy2;
    [SerializeField] public GameObject _enemy3;
    [SerializeField] public GameObject puerta;

    // Listas para rastrear diferentes tipos de enemigos
    private List<ShowHealthBar> activeEnemies = new List<ShowHealthBar>();
    private List<TurkeyShowHealthBar> activeTurkeyEnemies = new List<TurkeyShowHealthBar>();
    private List<FoxShowHealthBar> activeFoxEnemies = new List<FoxShowHealthBar>();

    public int EnemigosEliminados { get; private set; }
    public static int CantidadEnemigosParaAbrir { get; private set; } = 3;

    private void Awake()
    {
        Instance = this;
        if (Instance != this)
        {
            Destroy(gameObject);
        }
    }

    // M�todos para agregar y remover enemigos de las listas correspondientes
    public void AddActiveEnemy(ShowHealthBar enemy)
    {
        activeEnemies.Add(enemy);
    }

    public void RemoveActiveEnemy(ShowHealthBar enemy)
    {
        activeEnemies.Remove(enemy);
    }

    public void AddActiveTurkeyEnemy(TurkeyShowHealthBar turkeyEnemy)
    {
        activeTurkeyEnemies.Add(turkeyEnemy);
    }

    public void RemoveActiveTurkeyEnemy(TurkeyShowHealthBar turkeyEnemy)
    {
        activeTurkeyEnemies.Remove(turkeyEnemy);
    }

    public void AddActiveFoxEnemy(FoxShowHealthBar foxEnemy)
    {
        activeFoxEnemies.Add(foxEnemy);
    }

    public void RemoveActiveFoxEnemy(FoxShowHealthBar foxEnemy)
    {
        activeFoxEnemies.Remove(foxEnemy);
    }

    // M�todos generales para obtener la cantidad de enemigos
    public int GetNumberOfEnemies()
    {
        return activeEnemies.Count;
    }

    public int GetNumberOfTurkeyEnemies()
    {
        return activeTurkeyEnemies.Count;
    }

    public int GetNumberOfFoxEnemies()
    {
        return activeFoxEnemies.Count;
    }

    private void Start()
    {
        _enemy.SetActive(false);
        _enemy2.SetActive(false);
        _enemy3.SetActive(false);
        puerta.SetActive(true);
    }

    public void EnemigoEliminado()
    {
        /*if (/* && EnemigosEliminados < CantidadEnemigosParaAbrir#1#)
        {
            EnemigosEliminados++;

            Debug.Log("Enemigo eliminado. Total: " + EnemigosEliminados);

            if (EnemigosEliminados >= CantidadEnemigosParaAbrir)
            {
                Debug.Log("AbrirPuerta llamado");
                AbrirPuerta();
            }
        }*/
    }

    public void AbrirPuerta()
    {
        Debug.Log("AbrirPuerta llamado");
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _enemy.SetActive(true);
            _enemy2.SetActive(true);
            _enemy3.SetActive(true);
        }
    }
}