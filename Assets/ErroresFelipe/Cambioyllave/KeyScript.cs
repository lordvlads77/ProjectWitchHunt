using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyScript : MonoBehaviour
{
    public DoorScript doorToOpen;

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            doorToOpen.ReduceRemainingEnemies(); // Reduce la cantidad de enemigos vivos en el DoorScript
            Destroy(gameObject);
        }
    }
}