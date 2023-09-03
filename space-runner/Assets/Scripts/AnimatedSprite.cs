using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatedSprite : MonoBehaviour
{
    public Sprite[] sprites;        // An array to store the sprite frames for the animation.
    public float framerate = 1f / 6f; // The frame rate at which the animation plays.
    public bool playOneTime = false; // Flag to determine if the animation should play only once.
    private SpriteRenderer spriteRenderer; // Reference to the SpriteRenderer component.
    private int frame;               // The current frame of the animation.
    private bool isAnimating = false; // Added flag to control animation state.

    // This method is called when the script instance is initialized.
    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>(); // Get the SpriteRenderer component attached to this GameObject.
    }

    // This method is called when the GameObject becomes active/enabled.
    private void OnEnable()
    {
        if (playOneTime)
        {
            isAnimating = true; // Set the animation flag to true for one-time play.
            StartCoroutine(AnimateOneTime()); // Start the one-time animation coroutine.
        }
        else
        {
            // Start repeating the animation using the specified frame rate.
            InvokeRepeating(nameof(Animate), framerate, framerate);
        }
    }

    // This method is called when the GameObject becomes inactive/disabled.
    private void OnDisable()
    {
        if (playOneTime)
        {
            isAnimating = false; // Stop the one-time animation.
        }
        else
        {
            CancelInvoke(); // Cancel the repeating animation.
        }
    }

    // Coroutine to play the animation once.
    private IEnumerator AnimateOneTime()
    {
        frame = 0;
        while (frame < sprites.Length && isAnimating)
        {
            spriteRenderer.sprite = sprites[frame]; // Set the sprite to the current frame.
            frame++;
            yield return new WaitForSeconds(framerate); // Wait for the specified frame rate.
        }
        isAnimating = false; // Animation is complete.
    }

    // Method to handle the animation (repeating).
    private void Animate()
    {
        frame++;
        if (frame >= sprites.Length)
        {
            frame = 0; // Reset to the first frame when reaching the end of the sprites array.
        }
        if (frame >= 0 && frame < sprites.Length)
        {
            spriteRenderer.sprite = sprites[frame]; // Set the sprite to the current frame.
        }
    }
}
