using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puerta : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (LlaveManager.TieneLlave())
            {
                LlaveManager.UsarLlave();
            }
        }
    }
}