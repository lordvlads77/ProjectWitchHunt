using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class RoomCreator : MonoBehaviour
{
    [SerializeField] private GameObject[] rooms;
    [SerializeField] private List<RoomInfo> roomsCreated = new List<RoomInfo>();
    [SerializeField] private bool firstBatchCompleted = false;
    [SerializeField] private bool requestingRoom = false;
    [SerializeField] private GameObject currentLevel;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private Vector3 _origiPlayerPosition;
    [SerializeField] private Transform _playerPosition;
    [SerializeField] private Animator _animator;
    [SerializeField] private GameObject _transitionObj = default;
    public List<EnemyChecker> deadenemies = new List<EnemyChecker>();

    private GameManager gameManager;

    IEnumerator RequestRoom()
    {
        while (GetRoom() == false)
        {
            yield return new WaitForEndOfFrame();
        }
        
        requestingRoom = false;
        Debug.Log("Room created!");
    }

    bool GetRoom()
    {
        int randomNumber = UnityEngine.Random.Range(0, rooms.Length);

        for (int i = 0; i < roomsCreated.Count; i++)
        {
            if (randomNumber == roomsCreated[i].roomID)
            {
                if (roomsCreated[i].activated)
                {
                    Debug.Log("El cuarto ya estaba previamente creado o activado");
                    return false;
                }
            }
        }

        if (!firstBatchCompleted)
        {
            if (currentLevel != null)
            {
                currentLevel.SetActive(false);
            }

            GameObject newRoom = Instantiate(rooms[randomNumber], _spawnPoint.position, rooms[randomNumber].transform.rotation);

            RoomInfo ri = new RoomInfo();
            ri.roomObject = newRoom;
            ri.roomID = randomNumber;
            ri.activated = true;

            roomsCreated.Add(ri);

            currentLevel = newRoom;

            if (roomsCreated.Count == rooms.Length)
            {
                firstBatchCompleted = true;
                DeactivateRooms();
            }
        }
        else
        {
            if (currentLevel != null)
            {
                currentLevel.SetActive(false);
            }

            for (int i = 0; i < roomsCreated.Count; i++)
            {
                if (randomNumber == roomsCreated[i].roomID)
                {
                    roomsCreated[i].roomObject.SetActive(true);
                    roomsCreated[i].activated = true;
                    currentLevel = roomsCreated[i].roomObject;

                    if (gameManager != null && gameManager.EnemigosEliminados >= GameManager.CantidadEnemigosParaAbrir)
                    {
                        gameManager.AbrirPuerta();
                    }
                }
            }

            int activatedCount = 0;
            for (int i = 0; i < roomsCreated.Count; i++)
            {
                if (roomsCreated[i].activated)
                {
                    activatedCount++;
                }
            }

            if (activatedCount == roomsCreated.Count)
            {
                DeactivateRooms();
            }
        }

        return true;
    }

    void DeactivateRooms()
    {
        for (int i = 0; i < roomsCreated.Count; i++)
        {
            roomsCreated[i].activated = false;
        }
    }

    private void Start()
    {
        gameManager = GameManager.Instance;

        if (gameManager == null)
        {
            Debug.LogError("GameManager no asignado en el inspector.");
            return;
        }

        if (requestingRoom)
        {
            return;
        }

        requestingRoom = true;
        StartCoroutine(RequestRoom());
        Debug.Log("Starting");
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag != "LevelChanger")
        {
            return;
        }


        
        requestingRoom = true;
        StartCoroutine(RequestRoom());
        StartCoroutine(toBlack());
        _playerPosition.transform.position = _origiPlayerPosition;
        Debug.Log("Spawning");
        //StartCoroutine(turnOffLights());
    }
    
    IEnumerator toBlack()
    {
        _transitionObj.SetActive(true);
        yield return new WaitForEndOfFrame();
        Fading.Instance.TransFade();
        yield return new WaitForSeconds(1f);
        _transitionObj.SetActive(false);
    }

    private bool CheckRequiredEnemies()
    {
        foreach (EnemyChecker deadenemy in deadenemies)
        {
            if (!deadenemy.isDead)
            {
                return false; // if the enemies are not dead
            }
        }
        return true; //if all the enemies are petados.
    }
}





[Serializable]
public class RoomInfo
{
    public GameObject roomObject;
    public int roomID;
    public bool activated;
}