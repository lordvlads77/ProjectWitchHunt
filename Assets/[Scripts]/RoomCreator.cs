using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class RoomCreator : MonoBehaviour
{
    [Header("Level Spawner Stuff")]
    [SerializeField] private GameObject[] rooms; //Todos los cuartos disponibles
    [SerializeField] private List<RoomInfo> roomsCreated = new List<RoomInfo>(); // [gameobject del cuarto 1, y su ID 1]
    [SerializeField] private bool firstBatchCompleted = false;
    [SerializeField] private bool requestingRoom = false;
    [SerializeField] private GameObject currentLevel;
    [SerializeField] private Transform _spawnPoint;
    
    [Header("Player Position Reset")]
    [FormerlySerializedAs("_ogPlayerPosition")] [SerializeField] private Vector3 _origiPlayerPosition;
    [SerializeField] private Transform _playerPosition;

    private void Awake()
    {
        _origiPlayerPosition = _playerPosition.position;
    }
    
    
    
    IEnumerator RequestRoom()
    {
        while (GetRoom()==false)
        {
            yield return new WaitForEndOfFrame();
        }

        requestingRoom = false;
        Debug.Log("Room created!");
    }

    bool GetRoom() //create or reactivate room
    {
        int randomNumber = UnityEngine.Random.Range(0, rooms.Length);//1

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

        if (!firstBatchCompleted) //primera vez creando los cuartos
        {
            Debug.Log("Vamos a crear el cuarto nuevo");
            if (currentLevel != null)
            {
                currentLevel.SetActive(false);
            }

            GameObject newRoom = Instantiate(rooms[randomNumber], _spawnPoint.position, rooms[randomNumber].transform.rotation);

            RoomInfo ri = new RoomInfo();
            ri.roomObject = newRoom; //guardando el cuarto
            ri.roomID = randomNumber; //guardando el random number que salió, que es su ID
            ri.activated = true;

            roomsCreated.Add(ri);

            currentLevel = newRoom;

            if (roomsCreated.Count == rooms.Length)
            {
                firstBatchCompleted = true;
                DeactivateRooms();
            }
        }
        else //----------------------------------- Si los cuartos ya estaban creados, solo hay que activarlos
        {
            if (currentLevel != null)
            {
                currentLevel.SetActive(false);
            }

            for (int i = 0; i < roomsCreated.Count; i++)
            {
                if (randomNumber == roomsCreated[i].roomID)
                {
                    Debug.Log("Vamos a reactivar un cuarto previamente creado, pero que no se encuentra en esta nueva batch");
                    roomsCreated[i].roomObject.SetActive(true); //3,7,6,10
                    roomsCreated[i].activated = true;
                    currentLevel = roomsCreated[i].roomObject;
                }
            }

            Debug.Log("Revisando si todos los cuartos están creados...");

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
                Debug.Log("Batch completado, reseteando IDs");
                DeactivateRooms();
            }
            else
            {
                Debug.Log("Batch no completado, continuar...");
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
        if (requestingRoom)
        {
            return;
        }

        requestingRoom = true;
        StartCoroutine(RequestRoom());
        _playerPosition.position = _origiPlayerPosition;
        Debug.Log("Spawning");
    }
}





[Serializable]
public class RoomInfo
{
    public GameObject roomObject;
    public int roomID;
    public bool activated;
}