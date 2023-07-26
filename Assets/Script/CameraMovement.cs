using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] GameObject player;

    private void Update()
    {
        if(this.gameObject.transform.position.y>player.transform.position.y)
        {
            this.gameObject.transform.position = new Vector3(0, player.transform.position.y, -10f);
        }
    }
}
