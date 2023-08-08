using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    private Vector2 position;
    private EnemyManager enemyManager;
    private float movementSpeed = 10;
    private Vector3 direction;
    private int randomNumber;
    private int damagePoint = 15;
    private int life = 2;
    private void Awake()
    {

        enemyManager = FindObjectOfType<EnemyManager>();
        position = enemyManager.GetEnemySpawnPosition();
        randomNumber = Random.Range(0, 2);
        
    }
    private void Start()
    {
        if (randomNumber == 1)
        {
            this.gameObject.transform.position = new Vector3(position.x -3, position.y + 1, 0);
            direction = Vector3.left;
        }
        else if(randomNumber==0)
        {
            this.gameObject.transform.position = new Vector3(position.x + 3, position.y + 1, 0);
            direction = Vector3.right;
        }
    }
    private void Update()
    {
        if(randomNumber == 1)
        {
            if (gameObject.transform.position.x > position.x - 2.9)
                direction = Vector3.left;
        }
        if(randomNumber ==0)
        {
            if (gameObject.transform.position.x < position.x + 2.9)
                direction = Vector3.right;
        }
    }
    private void FixedUpdate()
    {
        
        this.gameObject.transform.position += direction * movementSpeed * Time.deltaTime; 

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "Left")
        {
            direction = Vector3.right;
        }
        else if (collision.gameObject.name == "Right")
        {
            direction = Vector3.left;
        }
        else if (collision.gameObject.name == "Player"|| collision.gameObject.name == "Bullet")
        {
            Destroy(gameObject);
            //particles system to be done
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
