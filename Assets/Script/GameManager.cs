using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
     EnemyManager enemyManager;
     PlayerMovement player;
    
    private int score;
    private int YFloorPosition;
    private int XFloorPosition;

    public void Awake()
    {
        enemyManager = GameObject.FindAnyObjectByType<EnemyManager>();
        player = GameObject.FindAnyObjectByType<PlayerMovement>();
        GameObject.FindGameObjectWithTag("Player").SetActive(false);
        NewGame();
    }
    public void NewFloorPosition(int x,int y)
    {
        XFloorPosition = x;
        YFloorPosition = y;
        enemyManager.EnemySpawn( x, y);
    }

    public void PlayerTakeDamage(int damage)
    {
        player.takeDamage(damage);
    }

    public void NewGame()
    {
        player.gameObject.SetActive(true);
    }
    
    public void AddScore()
    {

    }
}
