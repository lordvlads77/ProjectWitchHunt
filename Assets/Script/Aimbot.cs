using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aimbot : MonoBehaviour
{
    public string etiquetaObjetivo = "Enemy";
    public string etiquetaObjetivo2 = "BiggerEnemy";
    private Transform objetivoActual;
    private float distanciaMinima = Mathf.Infinity;
    public float campoVision = 180f;
    public float rangoMaximo = 10f;
    public float cadenciaDisparo = 2f;
    public float velocidadBala = 10f;
    public GameObject balaPrefab;
    public Transform puntoDisparo;
    private float tiempoUltimoDisparo;
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
                        Disparar();
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

    void Disparar()
    {
        GameObject bala = Instantiate(balaPrefab, puntoDisparo.position, puntoDisparo.rotation);

        Rigidbody rb = bala.GetComponent<Rigidbody>();
        rb.velocity = puntoDisparo.forward * velocidadBala;

        Destroy(bala, 1f);
    }
}