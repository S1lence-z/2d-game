using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D playerBody;
    private Animator anim;
    private SpriteRenderer sprite;

    // Variables
    private float dirX = 0f;
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float jumpForce = 14f;

    // Possible player states
    private enum PlayerMovementState { idle, running, jumping, falling };

    // Start is called before the first frame update
    void Start()
    {
        playerBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal");
        // the multiplication ensures joystick support as the value can vary
        playerBody.velocity = new Vector2(dirX * moveSpeed, playerBody.velocity.y);

        if (Input.GetButtonDown("Jump"))
        {
            playerBody.velocity = new Vector2(playerBody.velocity.x, jumpForce);
        }
        UpdatePlayerAnimationState();
    }

    private void UpdatePlayerAnimationState()
    {
        PlayerMovementState state;

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

        // check for jumping and falling
        if (playerBody.velocity.y > .1f)
        {
            state = PlayerMovementState.jumping;
        }
        else if (playerBody.velocity.y < -.1f)
        {
            state = PlayerMovementState.falling;
        }
        // set the integer value of the enum variable state
        anim.SetInteger("currentState", (int)state);
    }
}
