using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorJugador : MonoBehaviour
{
    private int monedasRecogidas = 0;
    [SerializeField] Tienda tienda;
    [SerializeField] int cantidadMinimaParaAbrirTienda = 10;

    public void AgregarMonedas(int cantidad)
    {
        monedasRecogidas += cantidad;

        if (monedasRecogidas >= cantidadMinimaParaAbrirTienda)
        {
            tienda.AbrirTienda();
        }
    }
}