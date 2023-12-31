using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    [SerializeField]
    public Transform door;
    [SerializeField]
    public float doorSpeed = 1f;
    [SerializeField]
    public bool isUnlocked = false;
    [SerializeField]
    public Transform openTransform;
    [SerializeField]
    public Transform closeTransform;
    [SerializeField]
    private Vector3 targetPosition;
    [SerializeField]
    private float time;

    // Nueva variable para rastrear la cantidad de enemigos vivos
    private int remainingEnemies;

    // Referencia al GameManager
    private GameManager gameManager;

    void Start()
    {
        targetPosition = closeTransform.position;
        gameManager = GameManager.Instance;
        remainingEnemies = gameManager.GetNumberOfEnemies();
    }

    void Update()
    {
        if (isUnlocked && door.position != targetPosition)
        {
            door.transform.position = Vector3.Lerp(door.transform.position, targetPosition, time);
            time += Time.deltaTime * doorSpeed;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && isUnlocked)
        {
            targetPosition = openTransform.position;
            time = 0;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player" && isUnlocked)
        {
            targetPosition = closeTransform.position;
            time = 0;
        }
    }

    // M�todo para reducir la cantidad de enemigos vivos
    public void ReduceRemainingEnemies()
    {
        remainingEnemies--;

        if (remainingEnemies <= 0)
        {
            UnlockDoor();
        }
    }

    // M�todo para desbloquear la puerta
    private void UnlockDoor()
    {
        isUnlocked = true;
        // Otros efectos o acciones que desees realizar cuando la puerta se desbloquee
    }
}