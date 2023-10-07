using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController Instance { get; private set; }
    [SerializeField]
    Transform tr;
    [SerializeField]
    Rigidbody rb;
    [SerializeField]
    public float walkSpeed = 200;

    void Start()
    {
        tr = this.transform;
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        MoveControl();
    }

    public void MoveControl()
    {
        float deltaX = SimpleInput.GetAxis("Horizontal");
        float deltaZ = SimpleInput.GetAxis("Vertical");
        float deltaT = Time.deltaTime;
        Vector3 side = walkSpeed * deltaX * deltaT * tr.right;
        Vector3 forward = walkSpeed * deltaZ * deltaT * tr.forward;
        Vector3 direction = side + forward;
        direction.y = rb.velocity.y;
        rb.velocity = direction;
    }
}
