using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [SerializeField] private GameObject _enemy;
    [SerializeField] private GameObject _enemy2;
    [SerializeField] private GameObject _enemy3;
    [SerializeField] private GameObject puerta;

    private int enemigosEliminados = 0;
    private int cantidadEnemigosParaAbrir = 3;

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
        puerta.SetActive(true); // Asegúrate de que la puerta esté activada al inicio
    }

    // Método para llamar cuando un enemigo es eliminado
    public void EnemigoEliminado()
    {
        enemigosEliminados++;

        Debug.Log("Enemigo eliminado. Total: " + enemigosEliminados);

        if (enemigosEliminados >= cantidadEnemigosParaAbrir)
        {
            Debug.Log("AbrirPuerta llamado");
            AbrirPuerta();
        }
    }

    private void AbrirPuerta()
    {
        Debug.Log("AbrirPuerta llamado");
        puerta.SetActive(false);
    }
}