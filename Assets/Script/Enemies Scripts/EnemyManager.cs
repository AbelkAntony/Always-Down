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
    private int numberOfEnemyToSpwan;
    private int rangeOfEnemyToSpwan;

    private void Start()
    {
        gameManager = FindAnyObjectByType<GameManager>();
    }
    public void EnemySpawn(int x,int y)
    {
        numberOfEnemyToSpwan = Random.Range(1, rangeOfEnemyToSpwan);
        for(int i =0; i< numberOfEnemyToSpwan;i++)
        {
            XEnemyPosition = x;
            YEnemyPosition = y;
            int randomNumber = Random.Range(0, 2);
            if(randomNumber ==1)
            {
                CreateEnemy();
            }
        }
        rangeOfEnemyToSpwan++;
    }

    private void CreateEnemy()
    {
        int enemyindex = Random.Range(5, 6);
        switch(enemyindex)
        {
            case 0:
                enemySpawnPosition = new Vector3(XEnemyPosition, YEnemyPosition + 1, 0);
                break;
            case 1:
                enemySpawnPosition = new Vector3(XEnemyPosition, YEnemyPosition - 5, 0);
                break;
            case 2:
                xPosition = GetRandomPosition();
                enemySpawnPosition = new Vector3(xPosition, YEnemyPosition + 1, 0);
                break;
            case 3:
                xPosition = GetRandomPosition();
                enemySpawnPosition = new Vector3(xPosition, YEnemyPosition + 1.8f, 0);
                break;
            case 4:
                xPosition = GetRandomPosition();
                enemySpawnPosition = new Vector3(xPosition, YEnemyPosition, 0);
                break;
            case 5:
                xPosition = GetRandomPosition();
                enemySpawnPosition = new Vector3(xPosition, YEnemyPosition + 2, 0);
                break;
        }
        enemy = Instantiate(enemyPrefab[enemyindex], enemySpawnPosition, Quaternion.identity);
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
            xPosition = Random.Range(XEnemyPosition-29,XEnemyPosition -5);
        }
        else if (XEnemyPosition <= 0)
        {
            xPosition = Random.Range(XEnemyPosition+5, XEnemyPosition+ 29);
        }
        return xPosition;
    }

    public void AddScore(int score)
    {
        gameManager.AddScore(score);
    }

    public void DestroyEnemies()
    {
        GameObject[] enemies;
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        for (int i =0;i< enemies.Length;i++)
        {
            Destroy(enemies[i].gameObject);
        }
        
    }

    public void ResetState()
    {
        rangeOfEnemyToSpwan = 1;
    }

    public Vector3 GetPlayerPosition()
    {
        return gameManager.GetPlayerPosition();
    }
}
