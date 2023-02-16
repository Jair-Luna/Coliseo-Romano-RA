using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController characterController;
    public float speed = 10f;
    private float gravity = -9.81f;
    Vector3 velocity;

    public Transform groundCheck;
    public float sphereRadius = 0.3f;
    public LayerMask groundMask;

    bool isGrounded;

    public float jumpHeight = 1.8f;

    void Update()
    {
        //if(transform.position.x < -90)
        //{
        //    transform.position = new Vector3(-90, transform.position.y, transform.position.z);
        //}

        //if(transform.position.x > 80)
        //{
        //    transform.position = new Vector3(80, transform.position.y, transform.position.z);
        //}

        isGrounded = Physics.CheckSphere(groundCheck.position, sphereRadius, groundMask);

        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        if(Input.GetButtonDown("Space") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
        }
        
        characterController.Move(move * speed * Time.deltaTime);
        
        velocity.y += gravity * Time.deltaTime;

        characterController.Move(velocity * Time.deltaTime);


    }
}
