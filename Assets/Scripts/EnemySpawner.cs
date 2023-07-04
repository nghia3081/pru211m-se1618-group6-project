using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] enemyPrefabs; // An array of enemy prefabs to randomly spawn from.
    public float spawnRate = 1f; // The rate at which enemies will spawn.
    private float nextSpawnTime = 0f; // The time that the next enemy should spawn.
    private Camera mainCamera; // A reference to the main camera.

    void Start()
    {
        mainCamera = Camera.main;
    }

    void Update()
    {
        if (Time.time >= nextSpawnTime)
        {
            nextSpawnTime = Time.time + spawnRate;

            // Choose a random enemy prefab from the array.
            int randomIndex = Random.Range(0, enemyPrefabs.Length);
            GameObject enemyPrefab = enemyPrefabs[randomIndex];

            // Get the bounds of the camera view.
            float cameraHeight = 2f * mainCamera.orthographicSize;
            float cameraWidth = cameraHeight * mainCamera.aspect;
            float leftEdge = mainCamera.transform.position.x - cameraWidth / 2f;
            float rightEdge = mainCamera.transform.position.x + cameraWidth / 2f;
            float topEdge = mainCamera.transform.position.y + cameraHeight / 2f;
            float bottomEdge = mainCamera.transform.position.y - cameraHeight / 2f;

            // Choose a random position within the camera bounds.
            Vector3 randomPosition = new Vector3(Random.Range(leftEdge, rightEdge), Random.Range(bottomEdge, topEdge), 0f);

            // Spawn the enemy at the random position.
            Instantiate(enemyPrefab, randomPosition, Quaternion.identity);
        }
    }
}