using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private CharacterController controller;
    [SerializeField] private float speed = 12f;
    [SerializeField] private float jumpHeight = 2f;
    private float gravity = -15f;
    private float groundDistance = 0.4f;

    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundMask;

    Vector3 velocity;
    bool isGrounded;

    //TODO implement the new input system

    // Update is called once per frame
    void Update()
    {
        // Creates a little sphere at the feet of the player, who checks if the player is on the ground or not
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        // Controlls the movement of the player
        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);

        // Jump input
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        // Controlls the gravity fall
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}
