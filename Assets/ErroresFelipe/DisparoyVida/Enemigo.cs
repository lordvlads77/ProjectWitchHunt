using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Enemigo : MonoBehaviour
{
    public float vidaMaxima = 100f;
    float vidaActual;

    // Agrega un objeto de barra de vida en el Inspector para mostrar la vida del enemigo.
    public Image barraVida;

    // Referencia al objeto de la interfaz de usuario que muestra el contador de monedas (TextMeshProUGUI)
    public TextMeshProUGUI contadorMonedasText;

    // Contador de monedas
    private int contadorMonedas = 0;

    void Start()
    {
        vidaActual = vidaMaxima;

        // Configurar la barra de vida
        if (barraVida != null)
        {
            // Aseg�rate de que la barra de vida est� configurada correctamente en el Inspector.
        }
    }

    public void RecibirDanio(float cantidad)
    {
        vidaActual -= cantidad;

        // Actualizar la barra de vida
        if (barraVida != null)
        {
            // Ajusta el tama�o de la imagen para reflejar la vida actual en relaci�n con la vida m�xima.
            float porcentajeVida = vidaActual / vidaMaxima;
            barraVida.fillAmount = porcentajeVida;
        }

        if (vidaActual <= 0f)
        {
            Morir();
        }
    }

    void Morir()
    {
        // Incrementar el contador de monedas
        contadorMonedas++;

        // Imprime el valor actual del contador de monedas para depuraci�n
        Debug.Log("Contador de Monedas: " + contadorMonedas);

        // Actualizar el texto en la interfaz de usuario
        if (contadorMonedasText != null)
        {
            contadorMonedasText.text = contadorMonedas.ToString();
        }

        // Implementa cualquier l�gica adicional para cuando el enemigo muera
        Destroy(gameObject);
    }
}