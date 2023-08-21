using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorManager : MonoBehaviour
{
    [SerializeField] GameObject floorPrefab;
    private GameManager gameManager;
    private GameObject floor;
    //private GameObject[] floors;
    private int y = 15;
   // private int numberOfFloors=0;


    public void CreateFloor()
    {
        gameManager = FindObjectOfType<GameManager>();
        floor = Instantiate(floorPrefab);
        //floors[numberOfFloors] = floor;
        //numberOfFloors++;
        floor.transform.position = new Vector3(0, y, 0);
        y = y - 10;
        for (int i = 0; i < 10; i++)
        {
            floor = Instantiate(floorPrefab);
            //floors[numberOfFloors] = floor;
            //numberOfFloors++;
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
        //numberOfFloors = 0;
    }


}

