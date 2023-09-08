using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tienda : MonoBehaviour
{
    [SerializeField]
    private Text monedasText;
    [SerializeField]
    private int monedasJugador = 0; //Monedas para acumular
    public Producto[] precio;
    public Producto[] productos;

    private void Start()
    {
        ActualizarUI();
    }

    public void ComprarProducto(int productoIndex)
    {
        Producto producto = productos[productoIndex];
        if (monedasJugador >= producto.precio)
        {
            monedasJugador -= producto.precio;
            producto.Comprar();
            ActualizarUI();
        }
        else
        {
            Debug.Log("No tienes suficientes monedas para comprar este producto.");
        }
    }

    private void ActualizarUI()
    {
        monedasText.text = "Monedas: " + monedasJugador;
    }
}