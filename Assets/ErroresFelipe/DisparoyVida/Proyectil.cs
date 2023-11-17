using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Proyectil : MonoBehaviour
{
    private float damagePorDisparo;
    private string tagEnemigo;

    public void SetDamagePorDisparo(float damage)
    {
        damagePorDisparo = damage;
    }

    public void SetTagEnemigo(string tag)
    {
        tagEnemigo = tag;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag(tagEnemigo))
        {
            // Aplica daño al enemigo
            Enemigo scriptEnemigo = collision.collider.GetComponent<Enemigo>();
            if (scriptEnemigo != null)
            {
                scriptEnemigo.RecibirDanio(damagePorDisparo);
            }
        }

        // Destruye el proyectil después de impactar
        Destroy(gameObject);
    }
}