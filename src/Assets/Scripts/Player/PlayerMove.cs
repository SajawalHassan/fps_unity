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
    private float jumpCount = 2f;

    private void Start() {
        velocity.y = 0f;
    }

    // Update is called once per frame
    private void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, sphereRadius, groundMask);
        
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = 0f;
        }
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move.normalized * speed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && jumpCount != 1)
        {
            velocity.y = jumpHeight;
            jumpCount--;
        }

        if (isGrounded)
            jumpCount = 2f;

        velocity.y += gravity * Time.deltaTime * Time.deltaTime;
        controller.Move(velocity);
    }
}
