using UnityEngine;

public class PrefabScript : MonoBehaviour
{
    public Sprite[] sprites; // Array of sprites to choose from

    void Start()
    {
        // Choose a random sprite from the array
        Sprite sprite = sprites[Random.Range(0, sprites.Length)];

        // Assign the sprite to the prefab's renderer component
        GetComponent<SpriteRenderer>().sprite = sprite;
    }
}
