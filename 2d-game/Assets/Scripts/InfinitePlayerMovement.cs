using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfinitePlayerMovement : MonoBehaviour, IMovement
{
    // IMovement interface inheritance
    public bool IsEnabled => enabled;
    public IMovement.PlayerMovementState State => state;

    // Objects
    private Rigidbody2D playerBody;
    private Animator anim;

    private BoxCollider2D boxCollider;

    // Variables
    private static bool doubleJumpEnabled = false;
    private bool doubleJumpReady = false;
    private bool playerDoubleJumped = false;
    private bool isMovingLeft = false;
    [SerializeField] private LayerMask jumpableGround;
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float jumpForce = 14f;
    [SerializeField] private float secondJumpQuotient = .7f;

    public IMovement.PlayerMovementState state = IMovement.PlayerMovementState.idle;

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
        // Horizontal movement
        if (Input.GetKeyDown(KeyCode.S))
        {
            isMovingLeft = false;
            playerBody.velocity = new Vector2(moveSpeed, playerBody.velocity.y);
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            isMovingLeft = true;
            playerBody.velocity = new Vector2(-moveSpeed, playerBody.velocity.y);
        }
        if (Input.GetKeyUp(KeyCode.A) && isMovingLeft)
        {
            isMovingLeft = false;
            playerBody.velocity = new Vector2(moveSpeed, playerBody.velocity.y);
        }

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
        doubleJumpEnabled = true;
        GameSettings.SetPowerUpStatus(GameSettings.PowerUpType.DoubleJump);
    }

    public static void DisableDoubleJump()
    {
        doubleJumpEnabled = false;
        GameSettings.SetPowerUpStatus(GameSettings.PowerUpType.DoubleJump);
    }

    private bool IsGrounded()
    {
        return Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }

    private void UpdatePlayerAnimationState()
    {
        // Check for running, jumping and falling
        if (playerBody.velocity.y < -.1)
        {
            state = IMovement.PlayerMovementState.falling;
        }
        else if (playerBody.velocity.y > .1f)
        {
            state = IMovement.PlayerMovementState.jumping;
        }
        else if (playerBody.velocity.x > .1f)
        {
            state = IMovement.PlayerMovementState.running;
        }
        else
        {
            state = IMovement.PlayerMovementState.idle;
        }
        // Check for double jumping
        if (doubleJumpEnabled && !doubleJumpReady && playerDoubleJumped && !IsGrounded())
        {
            state = IMovement.PlayerMovementState.doubleJumping;
            playerDoubleJumped = false;
        }
        // Set the proper integer value of the enum variable state to enable the correct animation
        if (anim != null)
        {
            anim.SetInteger("currentState", (int)state);
        }
    }
}