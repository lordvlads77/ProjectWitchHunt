using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovv : MonoBehaviour
{
    [SerializeField] private FloatingJoystick _joystick;
    public float playerSpeed;
    [SerializeField] private Rigidbody _rigidbody;
    
    [SerializeField] private Animator _animator;
    private int _pSpeed = Animator.StringToHash("speed");

    private void Awake()
    {
        GameStateManager.Instance.OnGameStateChanged += OnGameStateChanged;
    }

    private void OnDestroy()
    {
        GameStateManager.Instance.OnGameStateChanged -= OnGameStateChanged;
    }
    
    private void OnGameStateChanged(GameState newGameState)
    {
        enabled = newGameState == GameState.Gameplay;
    }

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        _rigidbody.velocity = new Vector3(_joystick.Horizontal * playerSpeed, _rigidbody.velocity.y, _joystick.Vertical * playerSpeed);
        if (_joystick.Horizontal != 0 || _joystick.Vertical != 0)
        {
            transform.rotation = Quaternion.LookRotation(_rigidbody.velocity);
            _animator.SetFloat(_pSpeed, 15);
        }
        else
        {
            _animator.SetFloat(_pSpeed, 0);
        }
    }
}
