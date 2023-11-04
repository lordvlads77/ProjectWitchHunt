using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class BulletsVFXPool : MonoBehaviour
{
    public static BulletsVFXPool Instance { get; private set; }
    [FormerlySerializedAs("_bulletVFXPool")] public BulletType[] _bulletVFXPrefab;
    private List<GameObject> _projectilePool;

    private void Awake()
    {
        Instance = this;
        if (Instance != this)
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        _projectilePool = new List<GameObject>();
    }

    public void ShootBullet(BulletType.VFXBulletType _vfxBulletType)
    {
        for (int i = 0; i < _projectilePool.Count; i++)
        {
            if (!_projectilePool[i].activeInHierarchy)
            {
                if (_projectilePool[i].GetComponent<BulletType>()._vfxBulletType == _vfxBulletType)
                {
                    _projectilePool[i].transform.position = transform.position;
                    _projectilePool[i].transform.rotation = transform.rotation;
                    _projectilePool[i].SetActive(true);
                    return;
                }
            }
        }
        for (int i = 0; i < _bulletVFXPrefab.Length; i++)
        {
            if (_bulletVFXPrefab[i]._vfxBulletType == _vfxBulletType)
            {
                GameObject _bullet = Instantiate(_bulletVFXPrefab[i].gameObject, transform.position, transform.rotation);
                _projectilePool.Add(_bullet);
                return;
            }
        }
    }
}
