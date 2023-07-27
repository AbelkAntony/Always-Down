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
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Floor")
            floorManager.RepositionFloor(this.gameObject);
    }
}
