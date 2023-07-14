using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private float rotationSpeed = 180f;
    public float moveSpeed = 20f;
    public float speedMultiplier = 1.5f;
    public GameObject smokeTrailPrefab;
    public static long score = 0;
    public TextMeshProUGUI TextMeshProUGUI;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        score = 0;
    }

    void Update()
    {
        Quaternion rotate = transform.rotation;
        float z = rotate.eulerAngles.z;
        z -= Input.GetAxisRaw("Horizontal") * rotationSpeed * Time.deltaTime;
        rotate = Quaternion.Euler(0, 0, z);
        transform.rotation = rotate;

        Vector3 pos = transform.position;
        Vector3 velocity = new Vector3(0, Input.GetAxisRaw("Vertical") * moveSpeed * Time.deltaTime, 0);

        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
        {
            velocity *= speedMultiplier;

            GameObject smokeTrail = Instantiate(smokeTrailPrefab, transform.position, Quaternion.identity);
            smokeTrail.transform.parent = transform;

            Destroy(smokeTrail, 2.0f);
        }

        pos = pos + rotate * velocity;
        transform.position = pos;
        TextMeshProUGUI.text = $"Your score: {score}";
    }
}
