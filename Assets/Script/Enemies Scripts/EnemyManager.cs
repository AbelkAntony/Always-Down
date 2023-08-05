using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] GameObject enemySpawner;
    [SerializeField] GameObject[] enemyPrefab;
    private int XEnemyPosition;
    private int YEnemyPosition;
    private Vector3 enemySpawnPosition;

    public void EnemySpawn(int x,int y)
    {
        enemySpawnPosition = new Vector3(x, y + 2, 0);
        int randomNumber = Random.Range(1, 2);
        if(randomNumber ==1)
        {
            CreateEnemy();
        }
    }

    private void CreateEnemy()
    {
        int enemyindex = Random.Range(0, 5);
        GameObject Enemy = Instantiate(enemyPrefab[enemyindex],enemySpawnPosition,Quaternion.identity);
    }
}
