using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovementInput : MonoBehaviour
{
    private Vector2 moveInput;
    private Vector2 lookInput;

    InputActions input;

    private void OnEnable()
    {
        //* Enable the input
        input = new InputActions();
        input.Player.Enable();

        //* Move
        input.Player.Move.performed += SetMove;
        input.Player.Move.canceled += SetMove;

        //* Look
        input.Player.Look.performed += SetLook;
        input.Player.Look.canceled += SetLook;
    }

    private void OnDisable()
    {
        //* Move
        input.Player.Move.performed -= SetMove;
        input.Player.Move.canceled -= SetMove;

        //* Look
        input.Player.Look.performed -= SetLook;
        input.Player.Look.canceled -= SetLook;

        //* Disable the input
        input.Player.Disable();

    }

    private void SetMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }

    private void SetLook(InputAction.CallbackContext context)
    {
        lookInput = context.ReadValue<Vector2>();
    }

}
