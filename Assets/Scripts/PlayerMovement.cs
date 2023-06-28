using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private float rotationSpeed = 180f;
    public float moveSpeed = 30f;
    private bool isRunning = false;
    public float speedMultiplier = 1.5f;
    public GameObject smokeTrailPrefab;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame


private void Update()
{   
    //rotate with Z axis    
    Quaternion rotate = transform.rotation;
    float z = rotate.eulerAngles.z;
    z -= Input.GetAxisRaw("Horizontal") * rotationSpeed * Time.deltaTime;
    rotate = Quaternion.Euler(0, 0, z);
    transform.rotation = rotate;

    // Move player
    Vector3 pos = transform.position;
    Vector3 velocity = new Vector3(0, Input.GetAxisRaw("Vertical") * moveSpeed * Time.deltaTime, 0);

    // Check if shift key is held down
    if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
    {
        velocity *= 2.0f; // Double the player's speed

        // Spawn smoke trail as a child of the player object
        GameObject smokeTrail = Instantiate(smokeTrailPrefab, transform.position  , Quaternion.identity);
        smokeTrail.transform.parent = transform;

        Destroy(smokeTrail, 2.0f); // Destroy smoke trail after 2 seconds
    }

    pos = pos + rotate * velocity;
    transform.position = pos;
}
} 