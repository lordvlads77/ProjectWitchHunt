using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletType : MonoBehaviour
{
    public VFXBulletType _vfxBulletType;
    public float speed;
    public float time = 3;
    float _currentTime = default;
    
    private void OnEnable()
    {
        _currentTime = time;
    }
    
    void Update()
    {
        transform.Translate(Vector3.forward * (speed * Time.deltaTime));
        _currentTime -= Time.deltaTime;
        if (_currentTime <= 0)
        {
            gameObject.SetActive(false);
        }    
    }
    
    public enum VFXBulletType
    {
        PinkBulletQuick,
        BlueBulletSlow,
    }
}
