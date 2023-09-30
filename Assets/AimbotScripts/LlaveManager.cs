using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LlaveManager : MonoBehaviour
{
    private static bool tieneLlave = false;

    public static void ObtenerLlave()
    {
        tieneLlave = true;
        Debug.Log("¡Has obtenido una llave!");
    }

    public static bool TieneLlave()
    {
        return tieneLlave;
    }

    public static void UsarLlave()
    {
        if (tieneLlave)
        {
            Debug.Log("Has usado la llave para abrir la puerta y cambiar de nivel.");
        }
        else
        {
            Debug.Log("No tienes una llave para abrir la puerta.");
        }
    }
}