using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [SerializeField] private GameObject _enemy;
    [SerializeField] private GameObject _enemy2;
    [SerializeField] private GameObject _enemy3;
    [SerializeField] private GameObject puerta;
    [SerializeField] private bool puertaActiva = false;

    public int EnemigosEliminados { get; private set; } // Agrega esta línea
    public static int CantidadEnemigosParaAbrir { get; private set; } = 3; // Agrega esta línea

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
        _enemy.SetActive(false);
        _enemy2.SetActive(false);
        _enemy3.SetActive(false);
        puerta.SetActive(true);
    }

    public void EnemigoEliminado()
    {
        if (!puertaActiva && EnemigosEliminados < CantidadEnemigosParaAbrir)
        {
            EnemigosEliminados++;

            Debug.Log("Enemigo eliminado. Total: " + EnemigosEliminados);

            if (EnemigosEliminados >= CantidadEnemigosParaAbrir)
            {
                Debug.Log("AbrirPuerta llamado");
                AbrirPuerta();
            }
        }
    }

    public void AbrirPuerta()
    {
        Debug.Log("AbrirPuerta llamado");
        puerta.SetActive(false);
        puertaActiva = true;
    }
}