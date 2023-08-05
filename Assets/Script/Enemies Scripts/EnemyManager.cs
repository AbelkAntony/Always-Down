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
    private GameObject enemy;

    public void EnemySpawn(int x,int y)
    {
        XEnemyPosition = x;
        YEnemyPosition = y;
        int randomNumber = Random.Range(0, 2);
        if(randomNumber ==1)
        {
            CreateEnemy();
        }
    }

    private void CreateEnemy()
    {
        int enemyindex = Random.Range(0, 4);
        switch(enemyindex)
        {
            case 0:
                enemySpawnPosition = new Vector3(XEnemyPosition + 3, YEnemyPosition + 1, 0);
                enemy = Instantiate(enemyPrefab[enemyindex],enemySpawnPosition,Quaternion.identity);
                break;
            case 1:
                enemySpawnPosition = new Vector3(XEnemyPosition, YEnemyPosition + 3, 0);
                enemy = Instantiate(enemyPrefab[enemyindex], enemySpawnPosition, Quaternion.identity);
                break;
            case 2:
                enemySpawnPosition = new Vector3(XEnemyPosition + 3, YEnemyPosition + 1, 0);
                enemy = Instantiate(enemyPrefab[enemyindex], enemySpawnPosition, Quaternion.identity);
                break;
            case 3:
                enemySpawnPosition = new Vector3(XEnemyPosition +1, YEnemyPosition + 3, 0);
                enemy = Instantiate(enemyPrefab[enemyindex], enemySpawnPosition, Quaternion.identity);
                break;

        }
    }
    

    public Vector2 GetEnemySpawnPosition()
    {
        return new Vector2(XEnemyPosition, YEnemyPosition);
    }
}
