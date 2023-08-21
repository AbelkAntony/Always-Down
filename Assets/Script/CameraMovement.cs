using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] GameObject player;
    public float movementSpeed = 500f;

    private void Update()
    {
        if(this.gameObject.transform.position.y>player.transform.position.y)
        {
            this.gameObject.transform.position = new Vector3(0, player.transform.position.y, -10f);
        }
        else
            this.gameObject.transform.position += Vector3.down * movementSpeed* Time.deltaTime;
        
    }
}
