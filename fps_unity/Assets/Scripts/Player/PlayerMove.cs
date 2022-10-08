using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speed = 15f;
    public CharacterController controller;
    public float gravity = -30;
    public float sphereRadius = 0.4f;
    public Transform groundCheck;
    public LayerMask groundMask;
    public float jumpHeight = 3f;

    private Vector3 velocity;
    private bool isGrounded;

    private void Start() {
        velocity.y = 0f;
    }

    // Update is called once per frame
    private void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, sphereRadius, groundMask);
        
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move.normalized * speed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = jumpHeight;
        }

        velocity.y += gravity * Time.deltaTime * Time.deltaTime;
        controller.Move(velocity);
    }
}