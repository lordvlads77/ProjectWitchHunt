using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonGenerator : MonoBehaviour
{
    public class Cell
    {
        public bool visited = false;
        public bool[] status = new bool[4];
    }

    public Vector2 size;
    public int startPos = 0;
    public GameObject room;
    public Vector2 offset;

    private List<Cell> board;
    
    void Start()
    {
        MazeGenerator();
    }
    
    void Update()
    {
        
    }

    void GenerateDungeon()
    {
        for (int i = 0; i < size.x; i++)
        {
            for (int j = 0; j < size.y; j++)
            {
                Cell currentCell = board[Mathf.FloorToInt(i + j * size.x)];
                if (currentCell.visited)
                {
                    var newRoom = Instantiate(room, new Vector3(i * offset.x, 0, - j * offset.y), Quaternion.identity, transform).GetComponent<RoomBehavior>();
                    newRoom.UpdateRoom(currentCell.status);

                    newRoom.name += " " + i + " " + j;
                }
            }
        }
    }

    void MazeGenerator()
    {
        board = new List<Cell>();
        for (int i = 0; i < size.x; i++)
        {
            for (int j = 0; j < size.y; j++)
            {
                board.Add(new Cell());
            }
        }

        int currentCell = startPos;

        Stack<int> path = new Stack<int>();

        int loop = 0;

        while (loop < 1000)
        {
            loop++;
            
            board[currentCell].visited = true;

            if (currentCell == board.Count - 1)
            {
                break;
            }
            
            // Check the Cells Neighbours
            List<int> neighbours = CheckNeighbours(currentCell);

            if (neighbours.Count == 0)
            {
                if (path.Count == 0)
                {
                    break;
                }
                else
                {
                    currentCell = path.Pop();
                }
            }
            else
            {
                path.Push(currentCell);

                int newCell = neighbours[Random.Range(0, neighbours.Count)];

                if (newCell > currentCell)
                {
                    // The path is going down or right
                    if (newCell - 1 == currentCell)
                    {
                        board[currentCell].status[2] = true;
                        currentCell = newCell;
                        board[currentCell].status[3] = true;
                    }
                    else
                    {
                        board[currentCell].status[1] = true;
                        currentCell = newCell;
                        board[currentCell].status[0] = true;   
                    }
                }
                else
                {
                    // The path is going up or left
                    if (newCell + 1 == currentCell)
                    {
                        board[currentCell].status[3] = true;
                        currentCell = newCell;
                        board[currentCell].status[2] = true;
                    }
                    else
                    {
                        board[currentCell].status[0] = true;
                        currentCell = newCell;
                        board[currentCell].status[1] = true;   
                    }
                }
            }
        }
        GenerateDungeon();
    }

    List<int> CheckNeighbours(int cell)
    {
        List<int> neighbours = new List<int>();
        
        // check up neightbour
        if (cell - size.x >= 0 && !board[Mathf.FloorToInt(cell - size.x)].visited)
        {
            neighbours.Add(Mathf.FloorToInt(cell - size.x));
        }
        // check down neightbour
        if (cell + size.x < board.Count && !board[Mathf.FloorToInt(cell + size.x)].visited)
        {
            neighbours.Add(Mathf.FloorToInt(cell + size.x));
        }
        // check right neightbour
        if ((cell+1) % size.x != 0 && !board[Mathf.FloorToInt(cell + 1)].visited)
        {
            neighbours.Add(Mathf.FloorToInt(cell + 1));
        }
        // check left neightbour
        if (cell  % size.x != 0 && !board[Mathf.FloorToInt(cell - 1)].visited)
        {
            neighbours.Add(Mathf.FloorToInt(cell - 1));
        }
        return neighbours;
    }
}
