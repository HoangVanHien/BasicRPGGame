using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    [SerializeField] private GameObject smallEnemyPrefab;
    public List<RuntimeAnimatorController> smallEnemyAnimators = new List<RuntimeAnimatorController>();
    [SerializeField] private MapGenerator mapGenerator;

    public void RandomSpawn(int enemyCount, float triggerLenght, float chaseLenght)
    {
        for (int i = 0; i < enemyCount; i++)
        {
            Enemy newEnemy = Instantiate(smallEnemyPrefab, transform).GetComponent<Enemy>();
            newEnemy.triggerLenght = triggerLenght;
            newEnemy.chaseLenght = chaseLenght;
            newEnemy.characterAnimator.runtimeAnimatorController = smallEnemyAnimators[Random.Range(0, smallEnemyAnimators.Count)];
            newEnemy.transform.position = mapGenerator.RandomAvailablePos();
        }
    }
}
