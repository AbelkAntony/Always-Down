using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fan : MonoBehaviour
{

    private EnemyManager enemyManager;
    private int damagePoint = 20;
    private int life = 5;
    private int point = 15;
    private void Start()
    {
        enemyManager = FindAnyObjectByType<EnemyManager>();
    }
    private void Update()
    {
        this.gameObject.transform.Rotate(0f, 0.0f, .1f, Space.Self);
       if(this.gameObject.name=="Circle")
        {
            this.gameObject.transform.Rotate(0f, 0.0f, 1f, Space.Self);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "Player")
        {
            enemyManager.PlayerTakeDamage(damagePoint);
        }
    }
}
