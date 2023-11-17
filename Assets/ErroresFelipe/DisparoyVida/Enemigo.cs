using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemigo : MonoBehaviour
{
    public float vidaMaxima = 100f;
    float vidaActual;

    // Agrega un objeto de barra de vida en el Inspector para mostrar la vida del enemigo.
    public Image barraVida;

    void Start()
    {
        vidaActual = vidaMaxima;

        // Configurar la barra de vida
        if (barraVida != null)
        {
            // Asegúrate de que la barra de vida esté configurada correctamente en el Inspector.
        }
    }

    public void RecibirDanio(float cantidad)
    {
        vidaActual -= cantidad;

        // Actualizar la barra de vida
        if (barraVida != null)
        {
            // Ajusta el tamaño de la imagen para reflejar la vida actual en relación con la vida máxima.
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
        // Implementa cualquier lógica adicional para cuando el enemigo muera
        Destroy(gameObject);
    }
}