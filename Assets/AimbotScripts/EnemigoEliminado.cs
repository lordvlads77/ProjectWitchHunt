using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoEliminado : MonoBehaviour
{
    public static int enemigosEliminados = 0;

    public static void IncrementarEnemigosEliminados()
    {
        enemigosEliminados++;

        if (enemigosEliminados >= 3)
        {
            LlaveManager.ObtenerLlave();
        }
    }
}