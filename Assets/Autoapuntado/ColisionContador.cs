using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColisionContador : MonoBehaviour
{
    private int enemigosDerrotados = 0;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemigo"))
        {
            enemigosDerrotados++;
            Debug.Log("Enemigo derrotado. Contador: " + enemigosDerrotados);
        }
    }
}