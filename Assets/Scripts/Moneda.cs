using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moneda : MonoBehaviour
{
    [SerializeField] int valor = 1;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ControladorJugador jugador = other.GetComponent<ControladorJugador>();
            if (jugador != null)
            {
                jugador.AgregarMonedas(valor);
                Destroy(gameObject);
            }
        }
    }
}