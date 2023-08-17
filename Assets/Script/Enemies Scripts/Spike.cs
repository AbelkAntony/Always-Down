using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour
{
    private EnemyManager enemyManager;
    private float fireTimeIntervel = 4;
    public int life = 3;
    private int damagePoint = 10;
    private Vector3 enemyPosition;
    private int point = 30;

    private void Start()
    {
        enemyManager = FindAnyObjectByType<EnemyManager>();
        enemyPosition = this.gameObject.transform.position;
        InvokeRepeating(nameof(SpikeStatus),Time.deltaTime+1,this.fireTimeIntervel);
    }

    private void SpikeStatus()
    {
        Vector3 from = this.transform.position;
        if(from.y==enemyPosition.y)
        {
            this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y - 1.7f, this.transform.position.z);
            this.gameObject.layer = LayerMask.NameToLayer("Background");
        }
        else
        {
            this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y + 1.7f, this.transform.position.z);
            this.gameObject.layer = LayerMask.NameToLayer("Enemy");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Bullet")
        {
            Destroy(collision.gameObject);
            TakeDamage();
        }
        else if (collision.tag == "Player")
        {
            enemyManager.PlayerTakeDamage(damagePoint);
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
            enemyManager.AddScore(point);
            Destroy(gameObject);
        }
        else
        {
            life--;
        }
    }
}
