using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blade : MonoBehaviour
{
    private Vector2 position;
    private EnemyManager enemyManager;
    private float movementSpeed = 10;
    private Vector3 direction = Vector3.left;
    private void Awake()
    {

        enemyManager = FindObjectOfType<EnemyManager>();
        position = enemyManager.GetEnemySpawnPosition();

    }
    private void Update()
    {
        if (gameObject.transform.position.x < position.x - 10)
            direction = Vector3.right;
        else if (gameObject.transform.position.x >= position.x + 10)
            direction = Vector3.left;
    }

    private void FixedUpdate()
    {
        this.gameObject.transform.position += direction * movementSpeed * Time.deltaTime;
    }

    public void TakeDamage()
    {

    }

}
