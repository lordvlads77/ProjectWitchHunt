using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovv : MonoBehaviour
{
    [SerializeField] private FloatingJoystick _joystick;
    public float playerSpeed;
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField]
    private float speedMultiplier = 1f; // Multiplicador de velocidad actual
    [SerializeField]
    private Coroutine speedMultiplierCoroutine;

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
        _rigidbody.velocity = new Vector3(_joystick.Horizontal * playerSpeed * speedMultiplier, _rigidbody.velocity.y, _joystick.Vertical * playerSpeed * speedMultiplier);

        if (_joystick.Horizontal != 0 || _joystick.Vertical != 0)
        {
            transform.rotation = Quaternion.LookRotation(_rigidbody.velocity);
            _animator.SetFloat(_pSpeed, 15 * speedMultiplier); // Ajusta según sea necesario
        }
        else
        {
            _animator.SetFloat(_pSpeed, 0);
        }
    }
    public void ApplySpeedMultiplier(float multiplier)
    {
        // Detén la rutina anterior si está en ejecución
        if (speedMultiplierCoroutine != null)
        {
            StopCoroutine(speedMultiplierCoroutine);
        }

        // Aplica el multiplicador de velocidad temporalmente
        speedMultiplierCoroutine = StartCoroutine(ApplySpeedMultiplierCoroutine(multiplier));
    }

    private System.Collections.IEnumerator ApplySpeedMultiplierCoroutine(float multiplier)
    {
        speedMultiplier *= multiplier;

        // Espera hasta que se alcance la duración deseada (2 segundos)
        yield return new WaitForSeconds(4f);

        // Restaura el multiplicador de velocidad original
        ResetSpeedMultiplier();
    }

    public void ResetSpeedMultiplier()
    {
        speedMultiplier = 1f;
        AudioController.Instance.PlayPotionEndedSFX();
    }
}
