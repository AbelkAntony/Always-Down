using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorManager : MonoBehaviour
{
    [SerializeField] GameObject floorPrefab;
    [SerializeField] GameManager gameManager;
    GameObject floor;
    private int y = 15;


    private void Start()
    {
        floor = Instantiate(floorPrefab);
        floor.transform.position = new Vector3(0, y, 0);
        y = y - 6;
        for (int i = 0; i < 10; i++)
        {
            floor = Instantiate(floorPrefab);
            int x = Random.Range(-27, 27);
            floor.transform.position = new Vector3(x, y, 0);
            gameManager.NewFloorPosition(x, y);
            y = y - 6;
        }
    }

    public void RepositionFloor(GameObject floor)
    {
        int x = Random.Range(-27, 27);
        floor.transform.position = new Vector3(x, y, 0);
        gameManager.NewFloorPosition(x, y);
        y = y - 6;
    }
}

