using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    private EnemyManager enemyManager;
    private GameObject fire;
    private bool fireStatus = true;
    private float fireTimeIntervel = 4;
    private int life = 3;
    private int damagePoint = 10;

    private void Start()
    {
        enemyManager = FindAnyObjectByType<EnemyManager>();
        fire = GameObject.Find("Fire");
        InvokeRepeating(nameof(FireStatus),this.fireTimeIntervel,this.fireTimeIntervel);
    }

    private void FireStatus()
    {
        if(fireStatus)
        {
            fire.SetActive(false);
            fireStatus = false;
        }
        else
        {
            fire.SetActive(true);
            fireStatus = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.name=="Bullet")
        {
            TakeDamage();
        }
        else if(collision.name=="Player")
        {
            enemyManager.PlayerTakeDamage(damagePoint);
        }
    }
    public void TakeDamage()
    {
        if(life<=0)
        {
            Destroy(gameObject);
        }
        else 
        {
            life--;
        }
    }
}
