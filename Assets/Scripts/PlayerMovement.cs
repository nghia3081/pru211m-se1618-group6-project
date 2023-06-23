using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
        private Rigidbody2D rb;
        private float rotationSpeed = 180f;
        public float moveSpeed = 20f;
       
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {   //rotate with Z axis    
        //lay phep quay khong gian 
        Quaternion rotate = transform.rotation;
        //lay toa do Z 
        float z = rotate.eulerAngles.z;
        //thay doi toa do Z theo input
        z -= Input.GetAxisRaw("Horizontal") * rotationSpeed * Time.deltaTime;
        //tao lai phep quay khong gian nhung chi lay toa do Z
        rotate = Quaternion.Euler(0,0,z);
        //thay lai vao bien rotate
        transform.rotation = rotate;

        //move player 
        Vector3 pos = transform.position;
        Vector3 velocity = new Vector3(0,Input.GetAxisRaw("Vertical")*moveSpeed * Time.deltaTime,0);
        pos = pos + rotate * velocity;
        transform.position = pos;
     
    }
}