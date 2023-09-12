using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Canon : MonoBehaviour
{
    [SerializeField] GameObject gun;
    [SerializeField] EnemyManager enemyManager;
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] GameObject gunPoint;
    private Vector3 targetDirection;
    private float speed = 10f;
    private float bulletSpeed = 1f;
    private int point = 30;
    private int life = 3;

    private void Start()
    {
        enemyManager = FindAnyObjectByType<EnemyManager>();
        InvokeRepeating(nameof(Fire), 2, 4);
        InvokeRepeating(nameof(Fire), 2.3f, 4);
    }
    private void Update()
    {
        float singleStep = speed * Time.deltaTime;
        targetDirection = enemyManager.GetPlayerPosition() -gun.transform.position;
        float rotZ = Mathf.Atan2(targetDirection.y, targetDirection.x) * Mathf.Rad2Deg;
        gun.transform.rotation = Quaternion.Euler(0,0,rotZ);
    }
    
    private void Fire()
    {
        Vector3 bulletDirection = enemyManager.GetPlayerPosition();
        GameObject bullet = Instantiate(bulletPrefab, gunPoint.transform.position, gunPoint.transform.rotation);
        bullet.gameObject.layer = LayerMask.NameToLayer("CanonBullet");
        //bullet.GetComponent<Rigidbody2D>().AddForce(targetDirection*bulletSpeed);
        BulletManager bulletManager = bullet.GetComponent<BulletManager>();
        bulletManager.BulletMovement(targetDirection,this.bulletSpeed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Bullet")
        {
            Debug.Log("bullet hit");
            TakeDamage();
        }
        else if (collision.gameObject.tag == "Floor Spawner")
        {
            Destroy(this.gameObject);
        }
    }

    public void TakeDamage()
    {
        if (life <= 0)
        {
           // Debug.Log("die");
            enemyManager.AddScore(point);
            Destroy(this.gameObject);
        }
        else
        {
           // Debug.Log(life);
            life--;
        }
    }
}

