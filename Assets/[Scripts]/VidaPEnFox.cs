using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidaPEnFox : MonoBehaviour
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
                AnimationController.Instance.EnemyFoxAttack(_animator);
                ParticleController.Instance.SpwnLightningParticlePDmgR();
            }
        }
    }
}
