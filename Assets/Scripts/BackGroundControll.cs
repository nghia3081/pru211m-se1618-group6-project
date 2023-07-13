using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpwnerControl : MonoBehaviour
{

    public GameObject[] EnemyGO;

    float maxSpawnRateInSeconds = 2f;
    // Start is called before the first frame update
    void Start()
    {
                Invoke("SpawnEnemy", maxSpawnRateInSeconds);

    }

    // Update is called once per frame
    void Update()
    {

    }

    void SpawnEnemy()
    {
        //bottom-left point of the screen
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));

        //top-right point of the screen
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

        //instantiate an enemy
        GameObject anEnemy = (GameObject)Instantiate(EnemyGO[Random.Range(0, EnemyGO.Length)]);

        anEnemy.transform.position = new Vector2(Random.Range(min.x, max.x), max.y);

        //schedule when to spawn next enemy
        ScheduleNextEnemySpawn();
    }

    void ScheduleNextEnemySpawn()
    {
        float spawnInSeconds;

        if (maxSpawnRateInSeconds > 1f)
        {
            //pick a number between 1 and maxSpawnRateInSeconds
            spawnInSeconds = Random.Range(1f, maxSpawnRateInSeconds);
        }
        else
        {
            spawnInSeconds = 1f;
        }

        Invoke("SpawnEnemy", spawnInSeconds);
    }



}
