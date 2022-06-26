using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    public List<GameObject> floorPieces = new List<GameObject>();
    private List<Vector3> availablePos = new List<Vector3>();

    [SerializeField] private EnemyGenerator enemyGenerator;

    public void GenerateNewMap(int mapWidth, int mapLength)
    {
        for (int i = 0; i < mapWidth; i++)
        {
            for (int j = 0; j < mapLength; j++)
            {
                GameObject newMap = Instantiate(floorPieces[Random.Range(0, floorPieces.Count)],transform);
                newMap.transform.position = new Vector3((float)i * 0.16f, (float)j * 0.16f);
            }
        }
        if(enemyGenerator == null)
        {
            Debug.Log("null");
            return;
        }
        enemyGenerator.RandomSpawn(5, 0.3f, 1f);
    }

    public Vector3 RandomAvailablePos()
    {
        return new Vector3(Random.Range(0, 0.16f * 30), Random.Range(0, 0.16f * 30));
    }
}
