using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorManager : MonoBehaviour
{
    [SerializeField] GameObject floorPrefab;
    private int y = 15;

    private void Awake()
    {
        for(int i =0; i<10;i++)
        {
            GameObject floor = Instantiate(floorPrefab);
            int x = Random.Range(-30, 30);
            floor.transform.position = new Vector3(x, y, 0);
            y = y - 5;
        }
    }

   public void RepositionFloor(GameObject floor)
    {
        int x = Random.Range(-30, 30);
        floor.transform.position = new Vector3(x, y, 0);
        y = y - 5;
    }
}

