using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorRepositioning : MonoBehaviour
{
    [SerializeField] GameManager gameManager;
    private FloorManager floorManager;

    private void Start()
    {
         floorManager = FindAnyObjectByType<FloorManager>();

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            floorManager.RepositionFloor(collision.gameObject);
        }
        else if (collision.gameObject.tag != "Player")
        {
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.tag == "Player")
        {
            gameManager.PlayerTakeDamage(100);
        }
    }
}
