using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageHandler : MonoBehaviour
{

    public int health = 2;
    int correctLayer;
    float invulTime = 0;
    // Start is called before the first frame update
    void Start()
    {   //set correctlayer = layer cua player
        correctLayer=gameObject.layer;
    }
    void OnTriggerEnter2D(){
        health--;
        invulTime = 1f;
        gameObject.layer = 8;
    }
    // Update is called once per frame
    void Update()
    {
        invulTime -= Time.deltaTime;
        if(invulTime <=0){
            gameObject.layer = correctLayer;
        }
        if(health <=0){
            Die();
        }
    }
    void Die(){
        Destroy(gameObject);
    }
}
