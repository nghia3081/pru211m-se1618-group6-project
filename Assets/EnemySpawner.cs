using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public Sprite[] enemySprites; // Array of possible enemy sprites

    public GameObject enemyPrefab; // Prefab for the enemy object to spawn

    public float minSpawnInterval = 1f; // Minimum time between spawns
    public float maxSpawnInterval = 5f; // Maximum time between spawns
    public float spawnIntervalDecrement = 0.1f; // Amount to decrement spawn interval each minute

    private float timer = 0f;
    private float spawnInterval = 0f;

    private void Start()
    {
        spawnInterval = Random.Range(minSpawnInterval, maxSpawnInterval);
    }

    private void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0f)
        {
            SpawnEnemy();
            timer = spawnInterval;
        }

        DecreaseSpawnInterval();
    }

    private void SpawnEnemy()
    {
        Vector3 spawnPosition = new Vector3(Random.Range(-10f, 10f), Random.Range(-5f, 5f), 0f);
        GameObject newEnemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
        int spriteIndex = Random.Range(0, enemySprites.Length);
        newEnemy.GetComponent<SpriteRenderer>().sprite = enemySprites[spriteIndex];
    }

    private void DecreaseSpawnInterval()
    {
        spawnInterval -= spawnIntervalDecrement * Time.deltaTime;
        spawnInterval = Mathf.Max(spawnInterval, minSpawnInterval);
    }
}