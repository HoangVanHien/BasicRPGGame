using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    class MazeCell
    {
        public MazeCell prevCell = null;
        public bool hasWallLeft = true;
        public bool hasWallDown = true;
        public List<char> ableDirection = new List<char> { 'u', 'd', 'l', 'r' };
    }

    int pieceXSize = 3;
    int pieceYSize = 3;

    public List<GameObject> floorPieces = new List<GameObject>();
    public GameObject wallLeft;
    public List<GameObject> wallDown = new List<GameObject>();
    public GameObject chest;
    public GameObject winObject;

    [SerializeField] private EnemyGenerator enemyGenerator;

    private void Start()
    {
        DifficultyMapGenerate(MySceneManager.instance.difficulty);
    }

    public void DifficultyMapGenerate(int diffiulty)
    {
        switch (diffiulty)
        {
            case 2:
                {
                    GenerateNewMap(30, 30);
                    break;
                }
            case 1:
                {
                    GenerateNewMap(20, 20);
                    break;
                }
            default:
                {
                    GenerateNewMap(10, 10);
                    break;
                }
        }
    }

    public void GenerateNewMap(int mapWidth, int mapHeight)
    {
        MazeCell[,] maze = MazeGenerate(mapWidth, mapHeight);

        for (int i = 0; i < mapWidth; i++)
        {
            for (int j = 0; j < mapHeight; j++)
            {
                Transform newMap = makeNewFloor(i, j);

                int wallOrderLayer = -2 * j * pieceYSize + 2;
                if (maze[i, j].hasWallDown)
                {
                    makeWallDown(newMap, wallOrderLayer, Vector3.zero);
                }
                if (maze[i, j].hasWallLeft)
                {
                    makeWallLeft(newMap, wallOrderLayer, Vector3.zero);
                }

                if (Random.Range(1, 100) <= 20)
                {
                    GameObject tmpChest = Instantiate(chest, newMap);
                    tmpChest.transform.localPosition = Vector3.zero;
                    tmpChest.GetComponent<Chest>().goldAmount = Random.Range(5, 50);
                }
            }
        }
        for (int i = 0; i < mapWidth; i++)
        {
            makeWallDown(transform, -2 * mapHeight * pieceYSize + 2, new Vector3((float)i * 0.16f * pieceXSize, (float)mapHeight * 0.16f * pieceYSize));
        }
        for (int j = 0; j < mapHeight; j++)
        {
            makeWallLeft(transform, -2 * j * pieceYSize + 2, new Vector3((float)mapWidth * 0.16f * pieceXSize, (float)j * 0.16f * pieceYSize));
        }

        winObject.transform.position = new Vector3((float)(mapWidth -1) * 0.16f * pieceXSize, (float)(mapHeight - 1) * 0.16f * pieceYSize);

        if (enemyGenerator == null)
        {
            Debug.Log("enemyGenerator null");
            return;
        }
        enemyGenerator.RandomSpawn((float)(mapWidth - 1) * 0.16f * (float)pieceXSize, (float)(mapHeight - 1) * 0.16f * (float)pieceYSize, mapWidth * mapHeight * pieceXSize * pieceYSize /100 +1, 0.3f, 1f);
    }

    private Transform makeNewFloor(int xMazeCount, int yMazeCount)
    {
        GameObject newMap = Instantiate(floorPieces[Random.Range(0, floorPieces.Count)], transform);
        newMap.transform.position = new Vector3((float)xMazeCount * 0.16f * pieceXSize, (float)yMazeCount * 0.16f * pieceYSize);
        newMap.name = "[" + xMazeCount + "," + yMazeCount + "]";
        for (float tmpI = -1; tmpI <= 1; tmpI++)
        {
            for (float tmpJ = -1; tmpJ <= 1; tmpJ++)
            {
                if (tmpI == 0 && tmpJ == 0) continue;

                GameObject tmpMap = Instantiate(floorPieces[Random.Range(0, floorPieces.Count)], newMap.transform);
                tmpMap.transform.localPosition = new Vector3(tmpI * 0.16f, tmpJ * 0.16f);
            }
        }
        return newMap.transform;
    }

    private void makeWallDown(Transform parent, int wallOrderLayer, Vector3 localPos)
    {
        GameObject newWallDown = Instantiate(wallDown[Random.Range(0, wallDown.Count)], parent);
        newWallDown.transform.localPosition = localPos;
        for (int tmpI = 0; tmpI < newWallDown.transform.childCount; tmpI++)
        {
            newWallDown.transform.GetChild(tmpI).GetComponent<SpriteRenderer>().sortingOrder = wallOrderLayer;
        }
    }
    private void makeWallLeft(Transform parent, int wallOrderLayer, Vector3 localPos)
    {
        GameObject newWallLeft = Instantiate(wallLeft, parent);
        newWallLeft.transform.localPosition = localPos;
        for (int tmpI = 0; tmpI < newWallLeft.transform.childCount; tmpI++)
        {
            newWallLeft.transform.GetChild(tmpI).GetComponent<SpriteRenderer>().sortingOrder = wallOrderLayer;
        }
    }

    private MazeCell[,] MazeGenerate(int mapWidth, int mapHeight)
    {
        MazeCell[,] maze = new MazeCell[mapWidth, mapHeight];
        Stack<int> xCellStack = new Stack<int>();
        Stack<int> yCellStack = new Stack<int>();

        int x, y;
        for (x = 0; x < mapWidth; x++)
        {
            for (y = 0; y < mapHeight; y++)
            {
                maze[x, y] = new MazeCell();
            }
        }

        maze[0, 0].prevCell = maze[0, 0];
        xCellStack.Push(0);
        yCellStack.Push(0);

        for (; xCellStack.Count > 0 && yCellStack.Count>0;)
        {
            x = xCellStack.Peek();
            y = yCellStack.Peek();
            MazeCell cell = maze[x, y];

            if(cell.ableDirection.Count <= 0)
            {
                xCellStack.Pop();
                yCellStack.Pop();
                continue;
            }

            if (y == 0)
            {
                if (cell.ableDirection.Contains('d')) cell.ableDirection.Remove('d');
            }
            else if (y == mapHeight - 1)
            {
                if (cell.ableDirection.Contains('u')) cell.ableDirection.Remove('u');
            }
            if (x == 0)
            {
                if (cell.ableDirection.Contains('l')) cell.ableDirection.Remove('l');
            }
            else if (x == mapWidth - 1)
            {
                if (cell.ableDirection.Contains('r')) cell.ableDirection.Remove('r');
            }

            switch(cell.ableDirection[Random.Range(0, cell.ableDirection.Count)])
            {
                case 'u':
                    {
                        cell.ableDirection.Remove('u');
                        if (maze[x, ++y].prevCell == null)
                        {
                            maze[x, y].prevCell = cell;
                            maze[x, y].hasWallDown = false;
                            xCellStack.Push(x);
                            yCellStack.Push(y);
                        }
                        break;
                    }
                case 'd':
                    {
                        cell.ableDirection.Remove('d');
                        if (maze[x, --y].prevCell == null)
                        {
                            maze[x, y].prevCell = cell;
                            cell.hasWallDown = false;
                            xCellStack.Push(x);
                            yCellStack.Push(y);
                        }
                        break;
                    }
                case 'l':
                    {
                        cell.ableDirection.Remove('l');
                        if (maze[--x, y].prevCell == null)
                        {
                            maze[x, y].prevCell = cell;
                            cell.hasWallLeft = false;
                            xCellStack.Push(x);
                            yCellStack.Push(y);
                        }
                        break;
                    }
                case 'r':
                    {
                        cell.ableDirection.Remove('r');
                        if (maze[++x, y].prevCell == null)
                        {
                            maze[x, y].prevCell = cell;
                            maze[x, y].hasWallLeft = false;
                            xCellStack.Push(x);
                            yCellStack.Push(y);
                        }
                        break;
                    }
            }
        }


        return maze;
    }
}
