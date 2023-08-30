using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class PlayerSpriteRenderer : MonoBehaviour
{
    private PlayerMovement movement;
    public SpriteRenderer spriteRenderer { get; private set; }
    public AnimatedSprite idle;
    public AnimatedSprite running;
    public Sprite jump;
    public Sprite fall;
    public AnimatedSprite doubleJumping;
    public AnimatedSprite death;

    private void Awake()
    {
        movement = GetComponentInParent<PlayerMovement>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void DisableAllMovement()
    {
        idle.enabled = false;
        running.enabled = false;
        doubleJumping.enabled = false;
    }

    private void LateUpdate()
    {
        if (!movement.enabled)
        {
            DisableAllMovement();
            death.enabled = true;
        }
        else
        {
            death.enabled = false;
            if (movement.state == PlayerMovement.PlayerMovementState.doubleJumping)
            {
                doubleJumping.enabled = true;
            }
            else { doubleJumping.enabled = false; }

            if (movement.state == PlayerMovement.PlayerMovementState.running)
            {
                running.enabled = true;
            }
            else { running.enabled = false; }

            if (movement.state == PlayerMovement.PlayerMovementState.idle && !running.enabled)
            {
                idle.enabled = true;
            }
            else { idle.enabled = false; }

            if (movement.state == PlayerMovement.PlayerMovementState.jumping)
            {
                spriteRenderer.sprite = jump;
            }
            else if (movement.state == PlayerMovement.PlayerMovementState.falling)
            {
                spriteRenderer.sprite = fall;
            }
        }
    }

    private void OnEnable()
    {
        spriteRenderer.enabled = true;
    }

    private void OnDisable()
    {
        spriteRenderer.enabled = false;
    }
}