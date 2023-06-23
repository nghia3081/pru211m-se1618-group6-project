using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMovement : MonoBehaviour
{
    public float moveSpeed = 15f;
    void Update(){
        Vector3 pos = transform.position;
        Vector3 velocity = new Vector3(0,moveSpeed * Time.deltaTime,0);
        pos += transform.rotation * velocity;
        transform.position = pos;
    }
}
