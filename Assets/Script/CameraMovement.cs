using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] GameObject player;
    private float movementSpeed = 500f;

    private void Update()
    {
        if(this.gameObject.transform.position.y>player.transform.position.y)
        {
            this.gameObject.transform.position = new Vector3(0, player.transform.position.y, -10f);
        }
        //this.gameObject.transform.position -= Time.deltaTime * Vector3.down * movementSpeed;
        
    }
}
