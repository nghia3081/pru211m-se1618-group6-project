using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageHandler : MonoBehaviour
{   
    public int health = 2;
    int correctLayer;
    float invulTimer = 0;
    public float invulPeriod = 0;

    // Start is called before the first frame update
    void Start()

    {
    //set correctlayer = layer cua player
    correctLayer=gameObject.layer;
    }
    void OnTriggerEnter2D(){
        health--;
        if(invulPeriod >0){
        invulTimer = invulPeriod;
        gameObject.layer = 8;
        }
       
  }
    // Update is called once per frame
    void Update()
    {   
        //invul
        if(invulTimer >0){
        invulTimer -= Time.deltaTime;   

        //not invul    
        if(invulTimer <=0){
        gameObject.layer = correctLayer;
        }
        }
        if(health <=0){
            Die();
        }
    }
    void Die(){
        Destroy(gameObject);
        
    }
}