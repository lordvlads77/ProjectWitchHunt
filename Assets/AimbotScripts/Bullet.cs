using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float velocidadBala = 10f;
    public Transform target; // Variable para el objetivo

    private void Update()
    {
        // En lugar de usar SetTarget, puedes usar directamente la variable target
        if (target != null)
        {
            // Calcula la dirección hacia el objetivo y mueve la bala en esa dirección
            Vector3 direccion = target.position - transform.position;
            transform.Translate(direccion.normalized * velocidadBala * Time.deltaTime, Space.World);
        }
        else
        {
            // Destruye la bala si no hay objetivo
            Destroy(gameObject);
        }
    }
}