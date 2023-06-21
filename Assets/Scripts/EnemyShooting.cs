using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float fireDelay = 0.5f;
    float cooldownTimer = 0;
    int bulletLayer;
    SpriteRenderer Sprite;
    public Vector3 bulletOffset = new Vector3(0,0.5f,0);
    void Start(){
        bulletLayer = gameObject.layer;
    }
    void Update()
    {
        cooldownTimer -= Time.deltaTime; 
        if( cooldownTimer <=0){
           
            cooldownTimer = fireDelay;
            Vector3 offsetBullet = transform.rotation * new Vector3(0,10f,0);
            GameObject bulletGO = (GameObject)Instantiate(bulletPrefab, transform.position + offsetBullet, transform.rotation);
            bulletGO.layer = bulletLayer;
        }
    }
}
