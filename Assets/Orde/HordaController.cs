using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HordaController : MonoBehaviour
{
    private Transform target; // El objetivo que la horda persigue (el jugador)
    private float velocidad;
    private float distanciaMaxima = 30.0f; // Define la distancia máxima antes de destruir al enemigo

    public void ConfigurarHorda(Transform nuevoTarget, float nuevaVelocidad)
    {
        target = nuevoTarget;
        velocidad = nuevaVelocidad;
    }

    void Update()
    {
        if (target != null)
        {
            // Calcula la distancia entre el enemigo y el jugador
            float distancia = Vector3.Distance(transform.position, target.position);

            // Si la distancia supera la distancia máxima, destruye al enemigo
            if (distancia > distanciaMaxima)
            {
                Destroy(gameObject);
                return; // Sal del Update después de destruir al enemigo
            }

            // Calcula la dirección hacia el jugador
            Vector3 direccion = (target.position - transform.position).normalized;

            // Mueve la horda hacia el jugador con la velocidad especificada
            transform.Translate(direccion * velocidad * Time.deltaTime);
        }
    }
}