using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestruct : MonoBehaviour
{
    public float SelfDestructTimer = 3f;
    
    // Update is called once per frame
    void Update()
    {
        SelfDestructTimer -= Time.deltaTime;
        if(SelfDestructTimer <=0){
            Destroy(gameObject);
        }
    }
}
