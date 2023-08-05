using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    Vector2 position;
    private EnemyManager enemyManager;
    private void Awake()
    {
        enemyManager = FindObjectOfType<EnemyManager>();
        position = enemyManager.GetEnemySpawnPosition();
        //this.gameObject.transform.position = position;
    }
}
