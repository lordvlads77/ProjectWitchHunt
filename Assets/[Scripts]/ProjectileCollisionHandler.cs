using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileCollisionHandler : MonoBehaviour
{
    public delegate void ProjectileCollisionHandlerDelegate(Collider other);
    public event ProjectileCollisionHandlerDelegate OnProjectileCollision;
    
    private void OnTriggerEnter(Collider other)
    {
        OnProjectileCollision?.Invoke(other);
    }
}
