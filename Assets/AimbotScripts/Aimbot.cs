using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aimbot : MonoBehaviour
{
    [SerializeField]
    private string etiquetaObjetivo = "Enemy";

    [SerializeField]
    private string etiquetaObjetivo2 = "BiggerEnemy";

    [SerializeField]
    private Transform objetivoActual;

    [SerializeField]
    private float distanciaMinima = Mathf.Infinity;

    [SerializeField]
    public float campoVision = 180f;

    [SerializeField]
    public float rangoMaximo = 10f;

    [SerializeField]
    public float cadenciaDisparo = 2f;

    [SerializeField]
    public float velocidadBala = 10f;

    [SerializeField]
    public GameObject balaPrefab;

    [SerializeField]
    public Transform puntoDisparo;

    [SerializeField]
    private float tiempoUltimoDisparo;

    [SerializeField]
    public int resistencia = 5;

    private bool estaDestruido = false;

    private void Update()
    {
        EncontrarObjetivoMasCercano();

        if (objetivoActual != null)
        {
            Vector3 direccion = objetivoActual.position - transform.position;
            float distancia = direccion.magnitude;

            if (distancia <= rangoMaximo)
            {
                float angulo = Vector3.Angle(direccion, transform.forward);

                if (angulo < campoVision / 2)
                {
                    Vector3 direccionSinY = direccion;
                    direccionSinY.y = 0;
                    Quaternion rotacionDeseada = Quaternion.LookRotation(direccionSinY);
                    transform.rotation = rotacionDeseada;

                    if (Time.time - tiempoUltimoDisparo > cadenciaDisparo)
                    {
                        Disparar(direccion); // Pasa la direcci�n al m�todo Disparar
                        tiempoUltimoDisparo = Time.time;
                    }
                }
            }
        }
    }

    void EncontrarObjetivoMasCercano()
    {
        distanciaMinima = Mathf.Infinity;
        objetivoActual = null;

        GameObject[] objetivos = GameObject.FindGameObjectsWithTag(etiquetaObjetivo);

        foreach (GameObject objetivo in objetivos)
        {
            if (objetivo != null)
            {
                Vector3 direccion = objetivo.transform.position - transform.position;
                float distancia = direccion.magnitude;

                if (distancia < distanciaMinima)
                {
                    distanciaMinima = distancia;
                    objetivoActual = objetivo.transform;
                }
            }
        }

        GameObject[] objetivos2 = GameObject.FindGameObjectsWithTag(etiquetaObjetivo2);

        foreach (GameObject objetivo in objetivos2)
        {
            if (objetivo != null)
            {
                Vector3 direccion = objetivo.transform.position - transform.position;
                float distancia = direccion.magnitude;

                if (distancia < distanciaMinima)
                {
                    distanciaMinima = distancia;
                    objetivoActual = objetivo.transform;
                }
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(etiquetaObjetivo) || collision.gameObject.CompareTag(etiquetaObjetivo2))
        {
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
    }

    void Disparar(Vector3 direccion)
    {
        GameObject bala = Instantiate(balaPrefab, puntoDisparo.position, puntoDisparo.rotation);

        // Configura el objetivo de la bala
        bala.GetComponent<Bullet>().SetTarget(objetivoActual);

        Rigidbody rb = bala.GetComponent<Rigidbody>();
        rb.velocity = direccion.normalized * velocidadBala;

        // Agrega la etiqueta del objetivo a la bala para que pueda detectar el tipo de objetivo
        bala.tag = objetivoActual.tag;

        Destroy(bala, 5f); // Cambia el tiempo de destrucci�n seg�n tus necesidades
    }
}
