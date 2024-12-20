using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed;
    private Vector2 _movedDirection;
    float horizontalMovement;

    [Header("Jump")]
    public float jumpPower;
    int maxJumps;
    int jumpsRemaining;

    [Header("Gravity")]
    public float baseGravity;
    public float maxFallSpeed;
    public float fallSpeedMultiplier;

    [Header("GroundCheck")]
    public Transform groundCheckPos;
    public Vector2 groundCheckSize = new Vector2(.3f, .05f);
    public LayerMask groundLayer;

    public Rigidbody2D currentCharacterRB;
    public Animator animator;

    private void Update() {
        Gravity();
        IsGrounded();

        if (currentCharacterRB.velocity.x > 0) {
            currentCharacterRB.transform.localScale = new Vector3(1, 1, 1);
        } else if (currentCharacterRB.velocity.x < 0) {
            currentCharacterRB.transform.localScale = new Vector3(-1, 1, 1);
        }
        animator.SetFloat("yVelocity", currentCharacterRB.velocity.y);
        animator.SetFloat("magnitude", currentCharacterRB.velocity.magnitude);
    }

    private void FixedUpdate() {
        currentCharacterRB.velocity = new Vector2(
            horizontalMovement * moveSpeed, currentCharacterRB.velocity.y
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

                currentCharacterRB.velocity = new Vector2(currentCharacterRB.velocity.x, actualJumpPower);
                jumpsRemaining--;
            } else if (context.canceled) {
                currentCharacterRB.velocity = new Vector2(currentCharacterRB.velocity.x, currentCharacterRB.velocity.y * 0.5f);
                jumpsRemaining--;
                animator.SetTrigger("jump");
            }
        }
    }

    private void Gravity(){
        if (currentCharacterRB.velocity.y < 0)
        {
            currentCharacterRB.gravityScale = baseGravity * fallSpeedMultiplier;
            currentCharacterRB.velocity = new Vector2(
                currentCharacterRB.velocity.x, MathF.Max(currentCharacterRB.velocity.y, -maxFallSpeed)
            );
        }
        else {
            currentCharacterRB.gravityScale = baseGravity;
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

    public void Setup(GameObject character) {
        currentCharacterRB = character.GetComponent<Rigidbody2D>();
        animator = character.GetComponent<Animator>();
        groundCheckPos = character.transform.GetChild(0);

        moveSpeed = GameManager.Instance.statusEffectMgr.playerStats.moveSpeed;
        jumpPower = GameManager.Instance.statusEffectMgr.playerStats.jumpPower;
        maxJumps = GameManager.Instance.statusEffectMgr.playerStats.maxJumps;
        baseGravity = GameManager.Instance.statusEffectMgr.playerStats.baseGravity;
        maxFallSpeed = GameManager.Instance.statusEffectMgr.playerStats.maxFallSpeed;
        fallSpeedMultiplier = GameManager.Instance.statusEffectMgr.playerStats.fallSpeedMultiplier;
    }
}
