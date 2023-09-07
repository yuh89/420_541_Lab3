using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    Rigidbody rb;
    float rotationY =0.0f;
    float verticalInput = 0.0f;
    float horizontalInput = 0.0f;
    public float speedValue = 50.0f;
    public float rotationSpeed = 10.0f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        verticalInput = Input.GetAxis("Vertical");
        
        horizontalInput = Input.GetAxis("Horizontal");
        float mouseX = Input.GetAxis("Mouse X");
        
        rotationY += mouseX*Time.deltaTime * rotationSpeed;
        transform.rotation = Quaternion.Euler(0.0f,rotationY,0.0f);
    }
    // Update is called once per frame
    void FixedUpdate()
    {


        Vector3 fowardMovement = verticalInput * transform.forward;
        Vector3 rightMovement = horizontalInput * transform.right;
        Vector3 direction = (fowardMovement + rightMovement);
        direction.Normalize();

        
        rb.AddForce(direction*speedValue );
        

    }
}
