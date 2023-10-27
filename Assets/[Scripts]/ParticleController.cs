using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class ParticleController : MonoBehaviour
{
    public static ParticleController Instance { get; private set; }
    [Header("Attack VFX")]
    [SerializeField] private Transform _attackTransform = default;
    [SerializeField] private GameObject _attackParticle = default;
    [Header("Damage VFX")]
    [SerializeField] private Transform _damageTransform = default;
    [SerializeField] private GameObject _damageParticle = default;
    [Header("AOE Damage VFX")]
    [SerializeField] private Transform _dmgAoeTransform = default;
    [SerializeField] private GameObject _dmgAoeParticle = default;
    [Header("Proyectiles VFX")]
    [SerializeField] private Transform _proyectilesTransform = default;
    [FormerlySerializedAs("_proyectilesParticle")] [SerializeField] private GameObject _proyectileBlueParticle = default;
    [SerializeField] private GameObject _proyectilePinkParticle = default;
    [Header("Lightning VFX")]
    [SerializeField] private Transform _lightningTransform = default;
    [SerializeField] private GameObject _lightningParticle = default;
    
    private void Awake()
    {
        Instance = this;
        if (Instance != this)
        {
            Destroy(gameObject);
        }
    }
    
    public void SpwnAttckParticle()
    {
        Instantiate(_attackParticle, _attackTransform.position, Quaternion.identity);
    }
    
    public void SpwnDmgParticle()
    {
        Instantiate(_damageParticle, _damageTransform.position, Quaternion.identity);
    }
    
    public void SpwnDmgAoeParticle()
    {
        Instantiate(_dmgAoeParticle, _dmgAoeTransform.position, Quaternion.identity);
    }
    
    public void SpwnProyectileBlueParticle()
    {
        Instantiate(_proyectileBlueParticle, _proyectilesTransform.position, Quaternion.identity);
    }
    
    public void SpwnProyectilePinkParticle()
    {
        Instantiate(_proyectilePinkParticle, _proyectilesTransform.position, Quaternion.identity);
    }
    
    public void SpwnLightningParticle()
    {
        Instantiate(_lightningParticle, _lightningTransform.position, Quaternion.identity);
    }
}
