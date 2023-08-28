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
    private float bulletSpeed = 100f;

    private void Start()
    {
        enemyManager = FindAnyObjectByType<EnemyManager>();
        InvokeRepeating(nameof(Fire), 2, 2);

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
        bullet.GetComponent<Rigidbody2D>().AddForce(targetDirection*bulletSpeed);
    }
}

