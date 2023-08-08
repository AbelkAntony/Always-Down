using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    private GameObject fire;
    private bool fireStatus = true;
    private float fireTimeIntervel = 4;

    private void Start()
    {
        fire = GameObject.Find("Fire");
        InvokeRepeating(nameof(FireStatus),this.fireTimeIntervel,this.fireTimeIntervel);
    }

    private void FireStatus()
    {
        if(fireStatus)
        {
            fire.SetActive(false);
            fireStatus = false;
        }
        else
        {
            fire.SetActive(true);
            fireStatus = true;
        }
    }
}
