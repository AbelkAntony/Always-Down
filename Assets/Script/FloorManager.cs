using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorManager : MonoBehaviour
{
    [SerializeField] GameObject floorPrefab;
    private GameManager gameManager;
    private GameObject floor;
    private int y;


    public void CreateFloor()
    {
        y = 15;
        gameManager = FindObjectOfType<GameManager>();
        floor = Instantiate(floorPrefab);
        floor.transform.position = new Vector3(0, y, 0);
        y = y - 10;
        for (int i = 0; i < 10; i++)
        {
            floor = Instantiate(floorPrefab);
            int x = Random.Range(-27, 27);
            floor.transform.position = new Vector3(x, y, 0);
            gameManager.NewFloorPosition(x, y);
            y = y - 10;
        }
    }

    public void RepositionFloor(GameObject floor)
    {
        int x = Random.Range(-27, 27);
        floor.transform.position = new Vector3(x, y, 0);
        gameManager.NewFloorPosition(x, y);
        y = y - 10;
    }

    public void DestroyFloors()
    {
        GameObject[] floors;
        floors = GameObject.FindGameObjectsWithTag("Floor");
        for (int i = 0; i < floors.Length; i++)
        {
            Destroy(floors[i].gameObject);
        }
    }


}

