using System;
using UnityEngine;

public class DisparoAutomatico : MonoBehaviour
{
    public static DisparoAutomatico Instance
    {
        get; private set;
    }
    public Transform puntoDisparo;
    public GameObject proyectil;
    public float velocidadDisparo = 15f;
    public float frecuenciaDisparoCercano = 1.5f;
    public float frecuenciaDisparoLejano = 0.5f;
    public float distanciaCercana = 5f;
    public float distanciaLejana = 15f;
    public string tagEnemigo = "Enemigo";
    public LayerMask capaEnemigos; // Asigna la capa de enemigos desde el Inspector
    public GameObject impactoParticulas;
    [SerializeField] private Animator _animator;
    private void Awake()
    {
        Instance = this;
        if (Instance != this)
        {
            Destroy(gameObject);
        }
        GameStateManager.Instance.OnGameStateChanged += OnGameStateChanged;
    }

    private void OnDestroy()
    {
        GameStateManager.Instance.OnGameStateChanged -= OnGameStateChanged;
    }

    private void Update()
    {
        float distanciaEnemigo = EncontrarEnemigoMasCercano();

        if (distanciaEnemigo <= distanciaCercana || distanciaEnemigo <= distanciaLejana)
        {
            Disparar(distanciaEnemigo <= distanciaCercana ? frecuenciaDisparoCercano : frecuenciaDisparoLejano);
        }
        else
        {
            CancelInvoke("HacerDisparo");
        }

        ApuntarAlEnemigo(distanciaEnemigo);
    }

    float EncontrarEnemigoMasCercano()
    {
        float distancia = Mathf.Infinity;
        GameObject[] enemigos = GameObject.FindGameObjectsWithTag(tagEnemigo);
        foreach (GameObject enemigo in enemigos)
        {
            float distanciaActual = Vector3.Distance(transform.position, enemigo.transform.position);
            if (distanciaActual < distancia)
            {
                distancia = distanciaActual;
            }
        }
        return distancia;
    }

    public void Disparar(float frecuenciaDisparo)
    {
        if (!IsInvoking("HacerDisparo"))
        {
            InvokeRepeating("HacerDisparo", 0f, frecuenciaDisparo);
        }
    }

    void HacerDisparo()
    {
        GameObject enemigoCercano = EncontrarEnemigoMasCercanoObject();
        if (enemigoCercano != null)
        {
            GameObject bala = Instantiate(proyectil, puntoDisparo.position, transform.rotation); // Las balas girar�n con el personaje
            Rigidbody rb = bala.GetComponent<Rigidbody>();
            Vector3 direccion = (enemigoCercano.transform.position - puntoDisparo.position).normalized;
            rb.velocity = direccion * velocidadDisparo;

            Physics.IgnoreCollision(bala.GetComponent<Collider>(), GetComponent<Collider>()); // Ignora la colisi�n con el jugador
            bala.layer = capaEnemigos; // Aplica la capa de enemigos a las balas
            
            //Subscribe to the OnCollisonEnter event for precise collision detection
            bala.GetComponent<ProjectileCollisionHandler>().OnProjectileCollision += HandleProjectileCollision;

            Destroy(bala, 3.0f);
            AnimationController.Instance.PlayerAttacking(_animator);
            ParticleController.Instance.SpwnAttckParticle();
        }
    }

    void HandleProjectileCollision(Collider other)
    {
        if (other.CompareTag(tagEnemigo) && impactoParticulas != null)
        {
            GameObject particles = Instantiate(impactoParticulas, other.transform.position, Quaternion.identity);
            Destroy(particles, 1.0f); // Adjust the lifetime as needed
        }
    }

    GameObject EncontrarEnemigoMasCercanoObject()
    {
        float distancia = Mathf.Infinity;
        GameObject enemigoCercano = null;
        GameObject[] enemigos = GameObject.FindGameObjectsWithTag(tagEnemigo);
        foreach (GameObject enemigo in enemigos)
        {
            float distanciaActual = Vector3.Distance(transform.position, enemigo.transform.position);
            if (distanciaActual < distancia)
            {
                distancia = distanciaActual;
                enemigoCercano = enemigo;
            }
        }
        return enemigoCercano;
    }

    void ApuntarAlEnemigo(float distanciaEnemigo)
    {
        if (distanciaEnemigo <= distanciaLejana)
        {
            GameObject enemigoCercano = EncontrarEnemigoMasCercanoObject();
            if (enemigoCercano != null)
            {
                Vector3 direccion = (enemigoCercano.transform.position - transform.position).normalized;
                puntoDisparo.rotation = Quaternion.LookRotation(direccion); // Apunta hacia el enemigo
            }
        }
    }
    
    private void OnGameStateChanged(GameState newGameState)
    {
        enabled = newGameState == GameState.Gameplay;
    }
}