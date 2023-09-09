using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    private EnemyManager enemyManager;
    private SpriteRenderer spriteRenderer;
    private Fire fire;
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
                this.gameObject.SetActive(false);
                fireStatus = false;
            }
            else
            {
                this.gameObject.SetActive(true);
                fireStatus = true;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
      
        if(collision.tag=="Player")
        {
            enemyManager.PlayerTakeDamage(damagePoint);
        }
        else if (collision.gameObject.tag == "Floor Spawner")
        {
            Destroy(this.gameObject);
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
