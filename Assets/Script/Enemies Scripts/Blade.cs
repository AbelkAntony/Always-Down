using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blade : MonoBehaviour
{
    private Vector2 position;
    private EnemyManager enemyManager;
    private float movementSpeed = 10;
    private Vector3 direction = Vector3.left;
    private int damagePoint = 20;
    public int life = 5;
    private void Awake()
    {

        enemyManager = FindObjectOfType<EnemyManager>();
        position = enemyManager.GetEnemySpawnPosition();

    }
    private void Update()
    {
        this.gameObject.transform.Rotate(0f, 0.0f, 1.0f, Space.Self);
        if (gameObject.transform.position.x < position.x - 10)
            direction = Vector3.right;
        else if (gameObject.transform.position.x >= position.x + 10)
            direction = Vector3.left;
    }

    private void FixedUpdate()
    {
        this.gameObject.transform.position += direction * movementSpeed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag=="Bullet")
        {
            TakeDamage();
        }
        else if (collision.tag=="Player")
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
