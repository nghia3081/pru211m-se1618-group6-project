using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageHandler : MonoBehaviour
{   DamageHandler Bubble;

    public int health = 2;
    int correctLayer;
    public float invulPeriod = 0;
    float invulTime = 0;
    // Start is called before the first frame update
    void Start()

    {
    //set correctlayer = layer cua player
    correctLayer=gameObject.layer;
    }
    void OnTriggerEnter2D(){
        health--;
        if(invulTime >0){
        invulTime = invulPeriod;
        gameObject.layer = 8;
        }
       
  }
    // Update is called once per frame
    void Update()
    {   
        //invul
        if(invulTime >0){
        invulTime -= Time.deltaTime;   

        //not invul    
        if(invulTime <=0){
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