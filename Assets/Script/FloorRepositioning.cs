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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("trigger");
        if(collision.gameObject.tag =="Floor")
        {
            floorManager.RepositionFloor(collision.gameObject);
            Debug.Log(collision);
            Debug.Log("triggeer repposition");
        }
        else
        {
            Destroy(collision.gameObject);
        }
    }
}
