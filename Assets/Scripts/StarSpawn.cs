using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarSpawn : MonoBehaviour
{
    public GameObject StarGO;
    public int maxStars;

    Color[] starColor = {
        new Color(0.5f, 0.5f, 1f),
		new Color(0, 1f, 1f),
		new Color(1f, 1f, 0),
		new Color(1f, 0, 0),
    };
    
    // Start is called before the first frame update
    void Start()
    {
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0,0));
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1,1));

        for(int i = 0; i < maxStars; i++){
            GameObject star = (GameObject)Instantiate(StarGO);
            star.GetComponent<SpriteRenderer>().color = starColor[i % starColor.Length];
            star.transform.position = new Vector2(Random.Range(min.x, max.x), max.y);
            star.GetComponent<Star>().speed = -(1f * Random.Range(1,30) + 20.5f);
            star.transform.parent = transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
