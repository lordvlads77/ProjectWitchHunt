using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    public static EnemyBehaviour Instance
    {
        get; private set;
    }
    public string playerTag = "Player";
    public float moveSpeed = 3f;
    public float live = 100f;
    public float vidarestante = 10f;
    public float vidatotal = default;

    private Transform player;
    private void Awake()
    {
        Instance = this;
        if(Instance = this)
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        player = GameObject.FindGameObjectWithTag(playerTag).transform;
    }

    void Update()
    {
        if (player != null)
        {
            transform.LookAt(player);
            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
        }
    }

    public void QuitarVida()
    {
        vidatotal = live - vidarestante;
    }
}