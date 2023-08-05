using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    Vector2 position;
    private EnemyManager enemyManager;
    private float movementSpeed = 10;
    private Vector3 direction = Vector3.right;
    private void Awake()
    {

        enemyManager = FindObjectOfType<EnemyManager>();
        position = enemyManager.GetEnemySpawnPosition();
        //this.gameObject.transform.position = position;
    }
    private void Update()
    {
        if (gameObject.transform.position.x < position.x + 2.9)
            direction = Vector3.right;
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
}
