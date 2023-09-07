using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fan : MonoBehaviour
{

    private EnemyManager enemyManager;
    private int damagePoint = 20;
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
        else if (collision.gameObject.tag == "Floor Spawner")
        {
            Destroy(this.gameObject);
        }
    }

   
}
