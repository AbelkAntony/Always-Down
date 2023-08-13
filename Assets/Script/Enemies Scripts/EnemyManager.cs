using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    private GameManager gameManager;
    [SerializeField] GameObject[] enemyPrefab;
    private int XEnemyPosition;
    private int YEnemyPosition;
    private int xPosition;
    private Vector3 enemySpawnPosition;
    private GameObject enemy;

    private void Start()
    {
        gameManager = FindAnyObjectByType<GameManager>();
    }
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
                enemySpawnPosition = new Vector3(XEnemyPosition, YEnemyPosition + 1, 0);
                enemy = Instantiate(enemyPrefab[enemyindex],enemySpawnPosition,Quaternion.identity);
                break;
            case 1:
                enemySpawnPosition = new Vector3(XEnemyPosition, YEnemyPosition - 3, 0);
                enemy = Instantiate(enemyPrefab[enemyindex], enemySpawnPosition, Quaternion.identity);
                break;
            case 2:
                xPosition = GetRandomPosition();
                enemySpawnPosition = new Vector3(xPosition, YEnemyPosition + 1, 0);
                enemy = Instantiate(enemyPrefab[enemyindex], enemySpawnPosition, Quaternion.identity);
                break;
            case 3:
                xPosition = GetRandomPosition();
                enemySpawnPosition = new Vector3(xPosition, YEnemyPosition + 1, 0);
                enemy = Instantiate(enemyPrefab[enemyindex], enemySpawnPosition, Quaternion.identity);
                break;

        }
    }
    

    public Vector2 GetEnemySpawnPosition()
    {
        return new Vector2(XEnemyPosition, YEnemyPosition);
    }

    public void PlayerTakeDamage(int damage)
    {
        gameManager.PlayerTakeDamage(damage);
    }

    private int GetRandomPosition()
    {
        int xPosition = 0;
        if (XEnemyPosition >0)
        {
            xPosition = Random.Range(XEnemyPosition-29,XEnemyPosition -3);
        }
        else if (XEnemyPosition <= 0)
        {
            xPosition = Random.Range(XEnemyPosition+3, XEnemyPosition+ 29);
        }
        return xPosition;
    }

    public void AddScore()
    {
        gameManager.AddScore();
    }
}
