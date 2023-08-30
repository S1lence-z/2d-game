using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class InfinitePlayerMovement : MonoBehaviour, IMovement
{
    // IMovement interface inheritance
    public bool IsEnabled => enabled;
    public IMovement.PlayerMovementState State => state;

    // Objects
    private Rigidbody2D playerBody;
    private Animator anim;
    private Camera cam;
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
    private float addedSpeed = 1f;
    private float lastSpeedIncreaseTime;
    private float speedIncreaseInterval = 15f;

    public IMovement.PlayerMovementState state = IMovement.PlayerMovementState.idle;

    private void Start()
    {
        playerBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
        cam = Camera.main;
    }

    private void Update()
    {
        CheckPlayerOutOfBounds();
        UpdatePlayerMovement();
        UpdatePlayerAnimationState();
        UpdatePlayerSpeed();
    }

    private void UpdatePlayerMovement()
    {
        // Horizontal movement
        if (Input.GetKeyDown(KeyCode.S))
        {
            MoveToTheRight();
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            MoveToTheLeft();
        }
        if (Input.GetKeyUp(KeyCode.A) && isMovingLeft)
        {
            MoveToTheRight();
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
    private void CheckPlayerOutOfBounds()
    {
        // Make sure the player does not go out of bounds to the left
        Vector3 leftEdge = cam.ScreenToWorldPoint(Vector2.zero);
        Vector3 rightEdge = cam.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        if (playerBody.position.x <= leftEdge.x + 1)
        {
            MoveToTheRight();
        }
    }

    private void UpdatePlayerSpeed()
    {
        if (Time.time - lastSpeedIncreaseTime >= speedIncreaseInterval)
        {
            lastSpeedIncreaseTime = Time.time;
            moveSpeed += addedSpeed;
        }
    }

    private void MoveToTheLeft()
    {
        isMovingLeft = true;
        playerBody.velocity = new Vector2(-moveSpeed, playerBody.velocity.y);
    }

    private void MoveToTheRight()
    {
        isMovingLeft = false;
        playerBody.velocity = new Vector2(moveSpeed, playerBody.velocity.y);
    }

    private void Jump(float jumpingForce, float jumpingQuotient)
    {
        playerBody.velocity = new Vector2(playerBody.velocity.x, jumpingForce * jumpingQuotient);
    }

    public static void EnableDoubleJump()
    {
        doubleJumpEnabled = !doubleJumpEnabled;
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
        // Check for running, jumping and falling
        if (playerBody.velocity.y < -.1f)
        {
            state = IMovement.PlayerMovementState.falling;
        }
        else if (playerBody.velocity.y > .1f)
        {
            state = IMovement.PlayerMovementState.jumping;
        }
        else if (playerBody.velocity.x > 0f)
        {
            state = IMovement.PlayerMovementState.running;
            transform.eulerAngles = Vector3.zero;
        }
        else if (playerBody.velocity.x < 0f)
        {
            state = IMovement.PlayerMovementState.running;
            transform.eulerAngles = new Vector3(0f, 180f, 0f);
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