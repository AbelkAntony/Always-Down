using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private GameManager gameManager;
    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rb;
    private float speed = 5f;
    private float jumpForce = 1500f;
    private float bulletSpeed = 2500f;
    private Vector2 bulletDirection = Vector2.right;
    private bool haveGun = true;
    private int playerHealth;
    [SerializeField] GameObject bulletprefab;
    [SerializeField] GameObject gunPoint;
    public Sprite[] sprites;
    private int spriteIndex;
    private Vector3 floorPosition =new Vector3(0,12,0);
    private void Start()
    {
        gameManager = FindAnyObjectByType<GameManager>();
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        ResetState();
    }

    public void takeDamage(int damage)
    {
        if(playerHealth>damage)
        {
            playerHealth -= damage;
            
        }
        else if(playerHealth<=damage )
        {
            playerHealth = 0;
            gameManager.GameOver();
        }
    }


    public int  GetPlayerHealth()       {       return playerHealth;       }
    public void SetPlayerHealth()       {       playerHealth = 100;        }
    private void Update()
    {
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            rb.AddForce(Vector2.right * speed);
            this.gameObject.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
            bulletDirection = Vector2.right;
            AnimateSprite();
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            rb.AddForce(Vector2.left * speed);
            this.gameObject.transform.rotation = Quaternion.Euler(new Vector3(0, 180, 0));
            bulletDirection = Vector2.left;
            AnimateSprite();
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector2.up * jumpForce);
        }
        if (Input.GetKeyDown(KeyCode.LeftControl) && haveGun)
        {
            GameObject bullet = Instantiate(bulletprefab, gunPoint.transform.position, gunPoint.transform.rotation);
            bullet.GetComponent<Rigidbody2D>().AddForce(bulletDirection * bulletSpeed);

        }

    }
    public void ResetState()
    {
        playerHealth = 100;
        this.transform.position = new Vector3(-30, this.transform.position.y, this.transform.position.z);
        floorPosition = new Vector3(0,12,0);
    }

    private void AnimateSprite()
    {
        spriteIndex++;
        if(spriteIndex>=sprites.Length)
        {
            spriteIndex = 0;
        }

        spriteRenderer.sprite = sprites[spriteIndex];
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (floorPosition.y > collision.transform.position.y)
        {
            floorPosition = collision.gameObject.transform.position;
            if (collision.gameObject.name == "Square" && floorPosition != Vector3.zero)
            {
                gameManager.AddScore(5);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag=="Bullet")
        {
            takeDamage(10);
        }
    }

}
