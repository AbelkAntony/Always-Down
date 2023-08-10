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

    private void Start()
    {
        enemyManager = FindAnyObjectByType<EnemyManager>();
        enemyPosition = this.gameObject.transform.position;
        InvokeRepeating(nameof(SpikeStatus),this.fireTimeIntervel,this.fireTimeIntervel);
    }

    private void SpikeStatus()
    {
        //Debug.Log("spikestatus");
        //float elapsed = 0f;
        //float duration = 0.1f;
        Vector3 from = this.transform.position;
        //Vector3 to;
        if(from.y==enemyPosition.y)
        {
           // Debug.Log("y--");
            this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y - 1, this.transform.position.z);
            
        }
        else
        {
           // Debug.Log("y++");
            this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y + 1, this.transform.position.z);
            /*to = new Vector3(this.transform.position.x, this.transform.position.y + 1, this.transform.position.z);
            this.transform.position = Vector3.Lerp(from, to, elapsed / duration);*/
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Bullet")
        {
            Destroy(collision.gameObject);
            TakeDamage();
        }
        else if (collision.name == "Player")
        {
            enemyManager.PlayerTakeDamage(damagePoint);
        }
    }
    public void TakeDamage()
    {
        if (life <= 0)
        {
            Destroy(gameObject);
        }
        else
        {
            life--;
        }
    }
}
