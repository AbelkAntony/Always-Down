using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorRepositioning : MonoBehaviour
{
    private FloorManager floorManager;
    private void Awake()
    {
         floorManager = FindAnyObjectByType<FloorManager>();

    }
 /*   private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Floorr collide");
        if (collision.gameObject.tag == "Floor")
        {
            floorManager.RepositionFloor(this.gameObject);
            Debug.Log("Floor RERppossitioning");
        }
    }*/
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("trigger");
        if(collision.gameObject.tag =="Floor")
        {
            floorManager.RepositionFloor(collision.gameObject);
            Debug.Log(collision);
            Debug.Log("triggeer repposition");
        }
    }
}
