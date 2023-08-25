using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Objects
    private Rigidbody2D playerBody;
    private Animator anim;
    private SpriteRenderer sprite;
    private BoxCollider2D boxCollider;

    // Variables
    private float dirX = 0f;
    private static bool doubleJumpEnabled = false;
    private bool doubleJumpReady = false;
    private bool playerDoubleJumped = false;
    [SerializeField] private LayerMask jumpableGround;
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float jumpForce = 15f;
    [SerializeField] private float secondJumpQuotient = .7f;

    // Possible player states
    private enum PlayerMovementState { idle, running, jumping, falling , doubleJumping };

    private void Start()
    {
        playerBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        UpdatePlayerMovement();
        UpdatePlayerAnimationState();
    }

    private void UpdatePlayerMovement()
    {
        // Horizontal movement (the multiplication ensures joystick support as the value can vary)
        dirX = Input.GetAxisRaw("Horizontal");
        playerBody.velocity = new Vector2(dirX * moveSpeed, playerBody.velocity.y);

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
    }    

    private bool IsGrounded()
    {
        return Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }

    private void UpdatePlayerAnimationState()
    {
        PlayerMovementState state;
        // Check if the player is moving to the left or to the right or not at all
        if (dirX > 0f)
        {
            state = PlayerMovementState.running;
            sprite.flipX = false;
        }
        else if (dirX < 0f)
        {
            state = PlayerMovementState.running;
            sprite.flipX = true;
        }
        else
        {
            state = PlayerMovementState.idle;
        }
        // Check for jumping and falling
        if (playerBody.velocity.y < -.1)
        {
            state = PlayerMovementState.falling;
        }
        else if (playerBody.velocity.y > .1f)
        {
            state = PlayerMovementState.jumping;
        }
        if (doubleJumpEnabled && !doubleJumpReady && playerDoubleJumped && !IsGrounded() )
        {
            state = PlayerMovementState.doubleJumping;
            playerDoubleJumped = false;
        }
        // Set the proper integer value of the enum variable state to enable the correct animation
        anim.SetInteger("currentState", (int)state);
    }
}
