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

        Vector3 movement = new Vector3(deltaX, 0f, deltaZ).normalized;
        Vector3 moveDirection = tr.TransformDirection(movement);

        rb.velocity = moveDirection * walkSpeed;
    }
}