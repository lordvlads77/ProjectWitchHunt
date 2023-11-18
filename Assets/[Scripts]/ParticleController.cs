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
    [Header("Lightning VFX Player Damage Receive")]
    [SerializeField] private Transform _lightningTransform = default;
    [SerializeField] private GameObject _lightningParticle = default;
    [SerializeField] private GameObject _lightningParticle2 = default;
    [SerializeField] private Transform _lightningTransform2 = default;
    [Header("Death Event Particle")]
    [SerializeField] private GameObject _deathParticle = default;
    [SerializeField] private Transform _deathTransform = default;
    [SerializeField] private Transform _deathEnemyTransform = default;
    [SerializeField] private Transform _deathEnemyTransform1 = default;
    [SerializeField] private Transform _deathEnemyTransform2 = default;
    [Header("Healing Particle")]
    [SerializeField] private GameObject _healingParticle = default;
    [SerializeField] private Transform _healingTransform = default;
    [SerializeField] private GameObject _healingParticle2 = default;
    [SerializeField] private Transform _healingTransform2 = default;
    [Header("Time until VFX Destruction")]
    [SerializeField] private float _destructionDelay = 1f;
    [FormerlySerializedAs("_destructionDelay2")] [SerializeField] private float _destructionDelayenemDmg = 3f;
    
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
        GameObject _atkMoveVFX = Instantiate(_attackParticle, _attackTransform.position, Quaternion.identity);
        Destroy(_atkMoveVFX, _destructionDelay);
        
    }
    
    public void SpwnDmgParticle()
    {
       GameObject _dmgEnemy = Instantiate(_damageParticle, _damageTransform.position, Quaternion.identity);
       Destroy(_dmgEnemy, _destructionDelayenemDmg);
        
    }
    
    public void SpwnDmgAoeParticle()
    {
        GameObject _AoeVFx = Instantiate(_dmgAoeParticle, _dmgAoeTransform.position, Quaternion.identity);
        Destroy(_AoeVFx, _destructionDelay);
    }
    
    public void SpwnProyectileBlueParticle()
    {
        BulletsVFXPool.Instance.ShootBullet(BulletType.VFXBulletType.BlueBulletSlow);
    }
    
    public void SpwnProyectilePinkParticle()
    {
        BulletsVFXPool.Instance.ShootBullet(BulletType.VFXBulletType.PinkBulletQuick);
    }
    
    public void SpwnLightningParticlePDmgR()
    {
        GameObject _PlayerRecieveDmg1 = Instantiate(_lightningParticle, _lightningTransform.position, Quaternion.identity);
        GameObject _PlayerRecieveDmg2 = Instantiate(_lightningParticle2, _lightningTransform2.position, Quaternion.identity);
        Destroy(_PlayerRecieveDmg1, _destructionDelay);
        Destroy(_PlayerRecieveDmg2, _destructionDelay);
    }
    
    public void SpwnDeathParticle()
    {
        GameObject _vfxPetacion = Instantiate(_deathParticle, _deathTransform.position, Quaternion.identity);
        Destroy(_vfxPetacion, _destructionDelay);
    }

    public void SpawnDeathVFXFox()
    {
        GameObject _DeathVfx = Instantiate(_deathParticle, _deathEnemyTransform.position, Quaternion.identity);
        Destroy(_DeathVfx, _destructionDelay);
    }

    public void SpawnDeathVFXTurkey()
    {
        GameObject _DeathVFX2 = Instantiate(_deathParticle, _deathEnemyTransform1.position, Quaternion.identity);
        Destroy(_DeathVFX2, _destructionDelay);
    }

    public void SpawnDeathVFXPig()
    {
        GameObject _DeathVFX3 = Instantiate(_deathParticle, _deathEnemyTransform2.position, Quaternion.identity);
        Destroy(_DeathVFX3, _destructionDelay);
    }
    
    public void SpwnHealingParticle()
    {
        GameObject _healVFX1 = Instantiate(_healingParticle, _healingTransform.position, _healingParticle.transform.rotation);
        GameObject _healVFX2 = Instantiate(_healingParticle2, _healingTransform2.position, _healingParticle2.transform.rotation);
        Destroy(_healVFX1, _destructionDelay);
        Destroy(_healVFX2, _destructionDelay);
    }
}
