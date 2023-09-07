using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HordaController : MonoBehaviour
{
    [SerializeField]
    private Transform target;

    [SerializeField]
    private float velocidad;

    [SerializeField]
    private float distanciaMaxima = 30.0f;

    public void ConfigurarHorda(Transform nuevoTarget, float nuevaVelocidad)
    {
        target = nuevoTarget;
        velocidad = nuevaVelocidad;
    }

    void Update()
    {
        if (target != null)
        {
            float distancia = Vector3.Distance(transform.position, target.position);
            if (distancia > distanciaMaxima)
            {
                Destroy(gameObject);
                return;
            }
            Vector3 direccion = (target.position - transform.position).normalized;
            transform.Translate(direccion * velocidad * Time.deltaTime);
        }
    }
}