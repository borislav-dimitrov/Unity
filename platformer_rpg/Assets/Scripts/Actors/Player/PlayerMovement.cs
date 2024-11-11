using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControls : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed = 5f;
    private Vector2 _movedDirection;
    float horizontalMovement;

    [Header("Jump")]
    public float jumpPower = 8f;
    int maxJumps = 2;
    int jumpsRemaining;

    [Header("Gravity")]
    public float baseGravity = 2f;
    public float maxFallSpeed = 18f;
    public float fallSpeedMultiplier = 2f;

    [Header("GroundCheck")]
    public Transform groundCheckPos;
    public Vector2 groundCheckSize = new Vector2(.3f, .05f);
    public LayerMask groundLayer;

    public Rigidbody2D rb;
    public Animator animator;


    private void Update() {
        Gravity();
        IsGrounded();

        if (rb.velocity.x > 0) {
            transform.localScale = new Vector3(1, 1, 1);
        } else if (rb.velocity.x < 0) {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        animator.SetFloat("yVelocity", rb.velocity.y);
        animator.SetFloat("magnitude", rb.velocity.magnitude);
    }

    private void FixedUpdate() {
        rb.velocity = new Vector2(
            horizontalMovement * moveSpeed, rb.velocity.y
        );
    }

    public void Move(InputAction.CallbackContext context) {
        horizontalMovement = context.ReadValue<Vector2>().x;
    }

    public void Jump(InputAction.CallbackContext context) {
        if (jumpsRemaining > 0) {
            if (context.performed) {
                float actualJumpPower = jumpPower;
                if (jumpsRemaining < maxJumps) {
                    // Reduce the force of double jumps to feel more natural
                    actualJumpPower *= .9f;
                    animator.SetTrigger("doubleJump");
                } else {
                    animator.SetTrigger("jump");
                }

                rb.velocity = new Vector2(rb.velocity.x, actualJumpPower);
                jumpsRemaining--;
            } else if (context.canceled) {
                rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
                jumpsRemaining--;
                animator.SetTrigger("jump");
            }
        }
    }

    private void Gravity(){
        if (rb.velocity.y < 0)
        {
            rb.gravityScale = baseGravity * fallSpeedMultiplier;
            rb.velocity = new Vector2(
                rb.velocity.x, MathF.Max(rb.velocity.y, -maxFallSpeed)
            );
        }
        else {
            rb.gravityScale = baseGravity;
        }
    }

    private void IsGrounded() {
        if (Physics2D.OverlapBox(groundCheckPos.position, groundCheckSize, 0, groundLayer))
        {
            jumpsRemaining = maxJumps;
            animator.ResetTrigger("doubleJump");
        }
    }
    private void OnDrawGizmosSelected() {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(groundCheckPos.position, groundCheckSize);
    }
}
