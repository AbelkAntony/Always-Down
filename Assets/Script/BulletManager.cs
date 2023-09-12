using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
    private Vector3 bulletDirection;
    private float bulletSpeed;


    private void Update()
    {
        this.gameObject.transform.position += bulletDirection * bulletSpeed * Time.deltaTime;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Destroy(collision.gameObject);
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(this.gameObject);
        //Debug.Log(collision.gameObject.name);
        if(collision.gameObject.name=="Player")
        {
            //Debug.Log(collision.gameObject.name);
        }
    }

    public void BulletMovement(Vector3 bulletDirection, float bulletSpeed)
    {
        this.bulletDirection = bulletDirection;
        this.bulletSpeed = bulletSpeed;
        //this.gameObject.transform.position += bulletDirection * bulletSpeed * Time.deltaTime;
    }
}
