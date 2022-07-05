using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    [SerializeField] private GameObject smallEnemyPrefab;
    public List<RuntimeAnimatorController> smallEnemyAnimators = new List<RuntimeAnimatorController>();

    public void RandomSpawn(float xMaxPos, float yMaxPos ,int enemyCount, float triggerLenght, float chaseLenght)
    {
        if (smallEnemyPrefab == null || smallEnemyAnimators.Count <= 0) return;
        for (int i = 0; i < enemyCount; i++)
        {
            Enemy newEnemy = Instantiate(smallEnemyPrefab, transform).GetComponent<Enemy>();
            newEnemy.triggerLenght = triggerLenght;
            newEnemy.chaseLenght = chaseLenght;
            newEnemy.characterAnimator.runtimeAnimatorController = smallEnemyAnimators[Random.Range(0, smallEnemyAnimators.Count)];
            newEnemy.transform.position = new Vector3(Random.Range(0.32f, xMaxPos), Random.Range(0.32f, yMaxPos), 0);
        }
    }
}
