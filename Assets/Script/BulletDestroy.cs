using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDestroy : MonoBehaviour
{

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(this.gameObject);
        Debug.Log(collision.gameObject.name);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag !="Floor")
        {
            Destroy(this.gameObject);
            Debug.Log(collision.gameObject);
        }
        
    }
}
