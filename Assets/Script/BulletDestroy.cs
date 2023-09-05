using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDestroy : MonoBehaviour
{

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
}
