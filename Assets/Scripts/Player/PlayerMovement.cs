using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private CustomInput input = null;

    private Vector2 moveVector = Vector2.zero;
    public float moveSpeed = 10;
    private float velocity;

    private Controller2D controller;
    private Animator animator;

    private void Awake()
    {
        input = new CustomInput();
        controller = GetComponent<Controller2D>();
        animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        input.Enable();
        input.Player.Move.performed += OnMovementPerformed;
        input.Player.Move.canceled += OnMovementCancelled;
    }

    private void OnDisable()
    {
        input.Disable();
        input.Player.Move.performed -= OnMovementPerformed;
        input.Player.Move.canceled -= OnMovementCancelled;
    }

    private void FixedUpdate()
    {
        animator.SetFloat("Velocity", MathF.Abs(moveVector.x));

        controller.Move(moveVector * moveSpeed * Time.fixedDeltaTime);
    }

    private void OnMovementPerformed(InputAction.CallbackContext value)
    {
        moveVector = value.ReadValue<Vector2>();
    }

    private void OnMovementCancelled(InputAction.CallbackContext value)
    {
        moveVector = Vector2.zero;
    }
}
