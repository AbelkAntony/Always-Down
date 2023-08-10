using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    private EnemyManager enemyManager;
    private GameObject fire;
    private bool fireStatus = true;
    private float fireTimeIntervel = 4;
    public int life = 3;
    private int damagePoint = 10;
    private bool died = false;

    private void Start()
    {
        enemyManager = FindAnyObjectByType<EnemyManager>();
        fire = GameObject.Find("Fire");
        InvokeRepeating(nameof(FireStatus),this.fireTimeIntervel,this.fireTimeIntervel);
    }

    private void FireStatus()
    {
        if(!died)
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
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag=="Bullet")
        {
            TakeDamage();
        }
        else if(collision.tag=="Player")
        {
            enemyManager.PlayerTakeDamage(damagePoint);
        }
    }
    public void TakeDamage()
    {
        life--;
        if (life<=0)
        {
            CancelInvoke(nameof(FireStatus));
            Destroy(gameObject);
        }
    }
}
