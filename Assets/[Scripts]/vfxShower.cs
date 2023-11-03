using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vfxShower : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            ParticleController.Instance.SpwnAttckParticle();
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            ParticleController.Instance.SpwnDmgParticle();
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            ParticleController.Instance.SpwnDmgAoeParticle();
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            ParticleController.Instance.SpwnProyectileBlueParticle();
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            ParticleController.Instance.SpwnProyectilePinkParticle();
        }
        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            ParticleController.Instance.SpwnLightningParticlePDmgR();
        }
        if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            ParticleController.Instance.SpwnDeathParticle();
        }
        if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            ParticleController.Instance.SpwnHealingParticle();
        }
    }
}
