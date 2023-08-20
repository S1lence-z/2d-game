using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private Rigidbody2D body;
    private SpriteRenderer sprite;
    private Animator anim;
    [SerializeField] private float verticalForce;
    [SerializeField] private float horizontalForce;
    private bool movingRight = false;
    private bool alreadyJumped = true;
    private movementType movement;

    private enum movementType 
    { 
        walking, 
        jumping, 
        jumpWalking
    };

    private void Start()
    {
        body = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        UpdateMovementState();
        MakePlayerMove();
    }

    private void UpdateMovementState()
    {
        if (horizontalForce != 0 && verticalForce == 0)
        {
            movement = movementType.walking;
        }
        else if (horizontalForce == 0 && verticalForce != 0)
        {
            movement = movementType.jumping;
        }
        else if (horizontalForce != 0 && verticalForce != 0)
        {
            movement = movementType.jumpWalking;
        }
    }
    private void MakePlayerMove()
    {
        switch(movement)
        {
            case movementType.walking:
                Walk(horizontalForce);
                break;

            case movementType.jumping:
                Jump(verticalForce);
                break;

            case movementType.jumpWalking:
                JumpWalk(verticalForce, horizontalForce);
                break;
        }
    }

    private void Jump(float forceY)
    {
        if (!alreadyJumped)
        {
            body.velocity = new Vector2(0, forceY);
            alreadyJumped = true;
        }
    }

    private void Walk(float forceX)
    {
        body.velocity = new Vector2(forceX * (movingRight ? 1 : -1), 0);
    }

    private void JumpWalk(float forceX, float forceY)
    {
        if (!alreadyJumped)
        {
            body.velocity = new Vector2(forceX * (movingRight ? 1 : -1), forceY);
            alreadyJumped = true;
        }
    }

    private void TurnAround()
    {
        movingRight = !movingRight;
        sprite.flipX = !sprite.flipX;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            TurnAround();
            alreadyJumped = false;
        }
        else
        {
            alreadyJumped = !alreadyJumped;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            anim.SetTrigger("playerHit");
        }
        StartCoroutine(Extensions.LoadAnimationWithDelay(anim, "Slime_Idle", .7f));
    }
}
