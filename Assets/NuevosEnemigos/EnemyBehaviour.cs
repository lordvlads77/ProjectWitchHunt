using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    public string playerTag = "Player";
    public float moveSpeed = 3f;
    public float minimumDistance = default;

    private Transform player;
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        GameStateManager.Instance.OnGameStateChanged += OnGameStateChange;
    }

    private void OnDestroy()
    {
        GameStateManager.Instance.OnGameStateChanged -= OnGameStateChange;
    }

    void Start()
    {
        player = GameObject.FindGameObjectWithTag(playerTag).transform;
    }

    void Update()
    {
        if (player != null)
        {
            // Calculate the distance between the enemy and the player
            float distanceToPlayer = Vector3.Distance(transform.position, player.position);
            if (distanceToPlayer > minimumDistance)
            {
                // Move towards the player, but stay at least minimumDistance away
                transform.LookAt(player);
                transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
            }
        }
    }
    
    private void OnGameStateChange(GameState newGameState)
    {
        enabled = newGameState == GameState.Gameplay;
    }
}