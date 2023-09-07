using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HordaController : MonoBehaviour
{
    private Transform target; // El objetivo que la horda persigue (el jugador)
    private float velocidad;

    public void ConfigurarHorda(Transform nuevoTarget, float nuevaVelocidad)
    {
        target = nuevoTarget;
        velocidad = nuevaVelocidad;
    }

    void Update()
    {
        if (target != null)
        {
            // Calcula la dirección hacia el jugador
            Vector3 direccion = (target.position - transform.position).normalized;

            // Mueve la horda hacia el jugador con la velocidad especificada
            transform.Translate(direccion * velocidad * Time.deltaTime);
        }
    }
}