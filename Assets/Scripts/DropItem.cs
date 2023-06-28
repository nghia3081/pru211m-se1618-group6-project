using UnityEngine;

public class DropItem : MonoBehaviour
{
    [SerializeField] private GameObject itemToDrop; // The item to drop
    [SerializeField] private float dropChance = 0.5f; // The chance of dropping the item
    public  AudioSource deathSFX;
    private void OnDestroy()
    {
        // Check if we should drop the item
        if (Random.Range(0f, 1f) <= dropChance)
        {
            // Spawn the item at the enemy's position
            Instantiate(itemToDrop, transform.position, Quaternion.identity);
            deathSFX.Play();
        }
    }
}