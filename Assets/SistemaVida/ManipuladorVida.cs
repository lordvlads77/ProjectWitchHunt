using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManipuladorVida : MonoBehaviour
{
    VidaGato playervida;
    public int cantidad;
    public float damageTime;
    float currentDamageTime;
    [SerializeField] private Animator _animator;

    void Start()
    {
        playervida = GameObject.FindWithTag("Player").GetComponent<VidaGato>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            currentDamageTime += Time.deltaTime;
            if (currentDamageTime > damageTime)
            {
                playervida.vida += cantidad;
                currentDamageTime = 0.0f;
                AnimationController.Instance.EnemyPigAttack(_animator);
            }
        }
    }
}
