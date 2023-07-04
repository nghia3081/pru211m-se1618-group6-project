using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TracingPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    Transform player;
    public float rotationSpeed = 90f;
    public long score = 5;
    // Update is called once per frame
    void Update()
    {
        if(player == null ){
            GameObject tracingPlayer = GameObject.FindWithTag("Player");
        
        if(tracingPlayer != null){
            player= tracingPlayer.transform;
        }

        }
        if(player == null){
            return;
        }
        Vector3 tracingDirection = player.position - transform.position;
        tracingDirection.Normalize();
        float zAngle = Mathf.Atan2(tracingDirection.y , tracingDirection.x) * Mathf.Rad2Deg - 90;
        Quaternion desiredRotation = Quaternion.Euler(0,0,zAngle);
        transform.rotation = Quaternion.RotateTowards(transform.rotation,desiredRotation,rotationSpeed*Time.deltaTime);
    }
}
