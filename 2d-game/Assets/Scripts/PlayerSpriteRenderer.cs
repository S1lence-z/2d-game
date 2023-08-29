using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class PlayerSpriteRenderer : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private PlayerMovement movement;

    [SerializeField] private AnimatedSprite idle;
    [SerializeField] private AnimatedSprite running;
    [SerializeField] private Sprite jump;
    [SerializeField] private Sprite fall;
    [SerializeField] private AnimatedSprite doubleJumping;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        movement = GetComponentInParent<PlayerMovement>();
    }

    private void LateUpdate()
    {
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

        
        if (movement.state == PlayerMovement.PlayerMovementState.doubleJumping)
        {
            doubleJumping.enabled = true;
        }
        else { doubleJumping.enabled = false; }

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