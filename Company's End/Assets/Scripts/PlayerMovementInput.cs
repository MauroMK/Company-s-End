using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovementInput : MonoBehaviour
{
    //* Input Fields
    InputActions playerInputActions;
    InputAction movement;

    //* Movement Fields
    private Rigidbody playerRb;
    [SerializeField] private float jumpForce = 3f;
    [SerializeField] private float movementForce = 1f;
    [SerializeField] private float maxSpeed = 5f;
    private Vector3 forceDirection = Vector3.zero;

    private Vector2 moveInput;

    //* References
    [SerializeField] private Camera playerCamera;

    public void Awake()
    {
        playerRb = GetComponent<Rigidbody>();
        playerInputActions = new InputActions();
    }

    private void OnEnable()
    {
        //* Takes the input into a variable and Enables the input
        movement = playerInputActions.Player.Move;
        movement.Enable();

        playerInputActions.Player.Jump.performed += DoJump;
        playerInputActions.Player.Jump.Enable();
    }

    private void OnDisable()
    {
        movement.Disable();
        playerInputActions.Player.Jump.performed -= DoJump;
        playerInputActions.Player.Jump.Disable();
    }

    private void DoJump(InputAction.CallbackContext obj)
    {
        if (IsGrounded())
        {
            forceDirection += Vector3.up * jumpForce;
        }
    }

    private bool IsGrounded()
    {
        Ray ray = new Ray(this.transform.position + Vector3.up * 0.25f, Vector3.down);
        if (Physics.Raycast(ray, out RaycastHit hit, 0.3f))
            return true;
        else
            return false;
    }

    private void FixedUpdate()
    {
        
    }

    private void SetMove(InputAction.CallbackContext ctx)
    {
        moveInput = ctx.ReadValue<Vector2>();
    }

    /* private void SetMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }

    private void SetLook(InputAction.CallbackContext context)
    {
        lookInput = context.ReadValue<Vector2>();
    } */
}
