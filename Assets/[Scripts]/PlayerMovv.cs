using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovv : MonoBehaviour
{
    [SerializeField] private FloatingJoystick _joystick;
    public float playerSpeed;
    [SerializeField] private Rigidbody _rigidbody;
    
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        _rigidbody.velocity = new Vector3(_joystick.Horizontal * playerSpeed, _rigidbody.velocity.y, _joystick.Vertical * playerSpeed);
    }
}
