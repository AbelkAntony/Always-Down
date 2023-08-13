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
    private bool playerAlive;

    [SerializeField] GameObject bulletprefab;
    [SerializeField] GameObject gunPoint;
    public Sprite[] sprites;
    private int spriteIndex;
    private void Start()
    {
        gameManager = FindAnyObjectByType<GameManager>();
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        ResetState();
        
        //AnimateSprite();
    }

    public void takeDamage(int damage)
    {
        if(playerHealth>damage)
            playerHealth -= damage;
        else if(playerHealth<=damage )
        {
            playerHealth = 0;
            playerAlive = false;
            gameManager.GameOver();
        }
    }

    public int  GetPlayerHealth()       {       return playerHealth;       }
    public bool IsPlayerAlive()         {       return playerAlive;        }    
    private void Update()
    {
        if(playerAlive)
        {
            if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                rb.AddForce(Vector2.right * speed);
                this.gameObject.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
                bulletDirection = Vector2.right;
                //AnimateSprite();
            }
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
                rb.AddForce(Vector2.left * speed);
                this.gameObject.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 180));
                bulletDirection = Vector2.left;
                //AnimateSprite();
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                rb.AddForce(Vector2.up * jumpForce);
                Debug.Log("Jump");
            }
            if (Input.GetKeyDown(KeyCode.LeftControl) && haveGun)
            {
                GameObject bullet = Instantiate(bulletprefab, gunPoint.transform.position, gunPoint.transform.rotation);
                Debug.Log("bullet created");
                bullet.GetComponent<Rigidbody2D>().AddForce(bulletDirection * bulletSpeed);
                Debug.Log("velocity");

            }
        }

    }
    private void ResetState()
    {
        playerHealth = 100;
        playerAlive = true;
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

    
}
