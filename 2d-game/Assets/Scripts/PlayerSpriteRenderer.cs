using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.VisualScripting.Dependencies.Sqlite;
using UnityEngine;

public class PlayerSpriteRenderer : MonoBehaviour
{
    private PlayerMovement movement;
    private InfinitePlayerMovement infiniteMovement;
    private IMovement activeMovementScript;
    public SpriteRenderer spriteRenderer;
    public AnimatedSprite idle;
    public AnimatedSprite running;
    public Sprite jump;
    public Sprite fall;
    public AnimatedSprite doubleJumping;
    public AnimatedSprite death;

    private void Awake()
    {
        movement = GetComponentInParent<PlayerMovement>();
        infiniteMovement = GetComponentInParent<InfinitePlayerMovement>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        SetActiveMovementScript();
    }

    private void SetActiveMovementScript()
    {
        if (infiniteMovement != null && infiniteMovement.enabled)
        {
            activeMovementScript = infiniteMovement;
        }
        else if (movement != null && movement.enabled)
        {
            activeMovementScript = movement;
        }
    }

    private void DisableAllMovement()
    {
        idle.enabled = false;
        running.enabled = false;
        doubleJumping.enabled = false;
    }

    private void LateUpdate()
    {
        if (!activeMovementScript.IsEnabled)
        {
            DisableAllMovement();
            death.enabled = true;
        }
        else
        {
            death.enabled = false;
            if (activeMovementScript.State == IMovement.PlayerMovementState.doubleJumping)
            {
                doubleJumping.enabled = true;
            }
            else { doubleJumping.enabled = false; }

            if (activeMovementScript.State == IMovement.PlayerMovementState.running)
            {
                running.enabled = true;
            }
            else { running.enabled = false; }

            if (activeMovementScript.State == IMovement.PlayerMovementState.idle && !running.enabled)
            {
                idle.enabled = true;
            }
            else { idle.enabled = false; }

            if (activeMovementScript.State == IMovement.PlayerMovementState.jumping)
            {
                spriteRenderer.sprite = jump;
            }
            else if (activeMovementScript.State == IMovement.PlayerMovementState.falling)
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