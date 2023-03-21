using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private CustomInput input = null;

    [SerializeField] private Vector2 moveVector = Vector2.zero;
    [SerializeField] private float moveSpeed = 10;
    private bool isRunning;

    private SpriteRenderer spriteRenderer;
    private Controller2D controller;
    private Animator animator;

    private void Awake()
    {
        input = new CustomInput();

        #region GetComponent
        spriteRenderer = GetComponent<SpriteRenderer>();
        controller = GetComponent<Controller2D>();
        animator = GetComponent<Animator>();
        #endregion
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

    private void Update()
    {
        #region Flip Sprite
        bool flipSprite = (spriteRenderer.flipX ? (moveVector.x > 0.01f) : (moveVector.x < -0.01f));
        if (flipSprite)
        {
            spriteRenderer.flipX = !spriteRenderer.flipX;
        }
        #endregion

        if (moveVector.x > 0.01f || moveVector.x < -0.01f || moveVector.y > 0.01f || moveVector.y < -0.01f)
        {
            isRunning = true;
        }
        else
        {
            isRunning = false;
        }

        animator.SetBool("IsRunning", isRunning);
    }

    private void FixedUpdate()
    {
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
