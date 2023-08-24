using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Canon : MonoBehaviour
{
    [SerializeField] GameObject gun;
    [SerializeField] EnemyManager enemyManager;
    private float speed = 10f;

    private void Start()
    {
        enemyManager = FindAnyObjectByType<EnemyManager>();
    }
    private void Update()
    {
        float singleStep = speed * Time.deltaTime;
        Vector3 targetDirection = enemyManager.GetPlayerPosition() -gun.transform.position;
        float rotZ = Mathf.Atan2(targetDirection.y, targetDirection.x) * Mathf.Rad2Deg;

        gun.transform.rotation = Quaternion.Euler(0,0,rotZ);
    }
}
