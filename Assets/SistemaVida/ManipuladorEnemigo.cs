using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManipuladorEnemigo : MonoBehaviour
{
    VidaGato playervida;
    public int cantidad;
    public float damageTime;
    float currentDamageTime;

    void Start()
    {
        playervida = GameObject.FindWithTag("Enemigo").GetComponent<VidaGato>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Enemigo")
        {
            currentDamageTime += Time.deltaTime;
            if (currentDamageTime > damageTime)
            {
                playervida.vida += cantidad;
                currentDamageTime = 0.0f;
            }
        }
    }
}
