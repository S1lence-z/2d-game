using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfinitePlayerMovement : MonoBehaviour
{
    // Objects
    private Rigidbody2D playerBody;
    private Animator anim;
    private BoxCollider2D boxCollider;

    // Variables
    private static bool doubleJumpEnabled = false;
    private bool doubleJumpReady = false;
    private bool playerDoubleJumped = false;
    [SerializeField] private LayerMask jumpableGround;
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float jumpForce = 15f;
    [SerializeField] private float secondJumpQuotient = .7f;

    // Possible player states
    private enum PlayerMovementState { idle, running, jumping, falling, doubleJumping };

    private void Start()
    {
        playerBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        UpdatePlayerMovement();
        UpdatePlayerAnimationState();
    }

    private void UpdatePlayerMovement()
    {
        // Horizontal movement - the player moves automatically to the right
        playerBody.velocity = new Vector2(moveSpeed, playerBody.velocity.y);

        // Jumping Logic
        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            doubleJumpReady = true;
            Jump(jumpForce, 1f);
        }
        // Double Jump Logic
        if (Input.GetButtonDown("Jump") && doubleJumpEnabled && doubleJumpReady && !IsGrounded())
        {
            doubleJumpReady = false;
            playerDoubleJumped = true;
            Jump(jumpForce, secondJumpQuotient);
        }
    }

    private void Jump(float jumpingForce, float jumpingQuotient)
    {
        playerBody.velocity = new Vector2(playerBody.velocity.x, jumpingForce * jumpingQuotient);
    }

    public static void EnableDoubleJump()
    {
        doubleJumpEnabled = !doubleJumpEnabled;
    }

    private bool IsGrounded()
    {
        return Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }

    private void UpdatePlayerAnimationState()
    {
        PlayerMovementState state;
        // Check for running, jumping and falling
        if (playerBody.velocity.y < -.1)
        {
            state = PlayerMovementState.falling;
        }
        else if (playerBody.velocity.y > .1f)
        {
            state = PlayerMovementState.jumping;
        }
        else
        {
            state = PlayerMovementState.running;
        }
        if (doubleJumpEnabled && !doubleJumpReady && playerDoubleJumped && !IsGrounded())
        {
            state = PlayerMovementState.doubleJumping;
            playerDoubleJumped = false;
        }
        // Set the proper integer value of the enum variable state to enable the correct animation
        anim.SetInteger("currentState", (int)state);
    }
}
