using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] EnemyManager enemyManager;
    [SerializeField] PlayerMovement player;
    private int YFloorPosition;
    private int XFloorPosition;
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
    
}
