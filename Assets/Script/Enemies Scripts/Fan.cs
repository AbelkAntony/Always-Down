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


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.name=="Player")
        {
            enemyManager.PlayerTakeDamage(damagePoint);
        }
        else if (collision.tag == "Bullet")
        {
            Debug.Log("bullet hit");
            TakeDamage();
        }
        else if (collision.gameObject.tag == "Floor Spawner")
        {
            Destroy(this.gameObject);
        }
    }

    public void TakeDamage()
    {
        if (life <= 0)
        {
            Debug.Log("die");
            enemyManager.AddScore(point);
            Destroy(this.gameObject);
        }
        else
        {
            Debug.Log(life);
            life--;
        }
    }
}
