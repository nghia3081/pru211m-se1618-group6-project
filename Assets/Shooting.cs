using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{       
    public float fireDelay = 0.5f;
    float reloadTimer = 0;
    // Update is called once per frame
    void Update()
    {
        reloadTimer -= Time.deltaTime;
        if(Input.GetButton("Fire1")  && reloadTimer <= 0 )
        {
            reloadTimer = fireDelay;
        }
    }
}
