using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform target; // Almacena el objetivo actual de la bala
    private float velocidadBala = 10f; // Velocidad de la bala

    // Método para establecer el objetivo de la bala
    public void SetTarget(Transform newTarget)
    {
        target = newTarget;
    }

    private void Update()
    {
        if (target != null)
        {
            // Calcula la dirección hacia el objetivo
            Vector3 direccion = target.position - transform.position;

            // Calcula la velocidad necesaria para alcanzar al objetivo
            Vector3 velocidad = direccion.normalized * velocidadBala;

            // Mueve la bala hacia el objetivo
            transform.Translate(velocidad * Time.deltaTime, Space.World);

            // Si la bala está lo suficientemente cerca del objetivo, destrúyela y al objetivo
            float distanciaToTarget = Vector3.Distance(transform.position, target.position);
            if (distanciaToTarget < 0.1f)
            {
                Destroy(target.gameObject);
                Destroy(gameObject);
            }
        }
        else
        {
            // Si el objetivo ya no existe, simplemente destruye la bala
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy") || other.CompareTag("BiggerEnemy"))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}