using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    private EnemyManager enemyManager;
    private SpriteRenderer spriteRenderer;
    private GameObject fire;
    private bool fireStatus = true;
    private float fireTimeIntervel = 4;
    public int life = 3;
    private int damagePoint = 10;
    private bool died = false;
    private int spriteIndex;
    public Sprite[] sprites;

    private void Start()
    {
        enemyManager = FindAnyObjectByType<EnemyManager>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        fire = GameObject.Find("Fire");
        InvokeRepeating(nameof(FireStatus),this.fireTimeIntervel,this.fireTimeIntervel);
    }
    private void FixedUpdate()
    {
        if(fireStatus)
        {
            AnimateSprite();
        }
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

    private void AnimateSprite()
    {
        spriteIndex++;
        if (spriteIndex >= sprites.Length)
        {
            spriteIndex = 0;
        }

        spriteRenderer.sprite = sprites[spriteIndex];
    }
}
