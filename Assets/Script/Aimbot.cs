using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aimbot : MonoBehaviour
{
    public Transform objetivo;
    public float campoVision = 180f;
    public float cadenciaDisparo = 2f;
    public float velocidadBala = 10f;
    public float tiempoDestruccionBala = 3f;
    public GameObject balaPrefab;
    public Transform puntoDisparo;
    private float tiempoUltimoDisparo;

    private void Update()
    {
        if (objetivo != null)
        {
            Vector3 direccion = objetivo.position - transform.position;

            float angulo = Vector3.Angle(direccion, transform.forward);

            if (angulo < campoVision / 2)
            {
                if (Time.time - tiempoUltimoDisparo > cadenciaDisparo)
                {
                    Disparar();
                    tiempoUltimoDisparo = Time.time;
                }
            }
        }
    }

    void Disparar()
    {
        GameObject bala = Instantiate(balaPrefab, puntoDisparo.position, puntoDisparo.rotation);

        Rigidbody rb = bala.GetComponent<Rigidbody>();
        rb.velocity = puntoDisparo.forward * velocidadBala;

        Destroy(bala, tiempoDestruccionBala);
    }
}