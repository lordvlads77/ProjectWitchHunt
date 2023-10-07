using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BiggerEnemy : MonoBehaviour
{
    [SerializeField]
    private int resistencia = 2;// Número de golpes requeridos para destruir el enemigo
    private bool estaDestruido = false;

    private void OnCollisionEnter(Collision collision)
    {
        if (!estaDestruido && collision.gameObject.CompareTag("Bullet"))
        {
            resistencia--;

            Destroy(collision.gameObject);

            if (resistencia <= 0)
            {
                estaDestruido = true;
                Destroy(gameObject);
            }
        }
    }
}