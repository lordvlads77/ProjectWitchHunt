using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelChanger : MonoBehaviour
{
    public GameObject levelCollider;

    private int enemiesKilled = 0;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            enemiesKilled++;
            if (enemiesKilled >= 4)
            {
                levelCollider.SetActive(false);
                // Código para cargar el siguiente nivel o realizar la transición que desees.
            }
        }
    }
}