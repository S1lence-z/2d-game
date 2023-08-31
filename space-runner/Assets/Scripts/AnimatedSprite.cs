using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatedSprite : MonoBehaviour
{
    public Sprite[] sprites;
    public float framerate = 1f / 6f;
    public bool playOneTime = false;
    private SpriteRenderer spriteRenderer;
    private int frame;
    private bool isAnimating = false; // Added flag to control animation state

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnEnable()
    {
        if (playOneTime)
        {
            isAnimating = true;
            StartCoroutine(AnimateOneTime());
        }
        else
        {
            InvokeRepeating(nameof(Animate), framerate, framerate);
        }
    }

    private void OnDisable()
    {
        if (playOneTime)
        {
            isAnimating = false;
        }
        else
        {
            CancelInvoke();
        }
    }

    private IEnumerator AnimateOneTime()
    {
        frame = 0;
        while (frame < sprites.Length && isAnimating)
        {
            spriteRenderer.sprite = sprites[frame];
            frame++;
            yield return new WaitForSeconds(framerate);
        }
        isAnimating = false;
    }

    private void Animate()
    {
        frame++;
        if (frame >= sprites.Length)
        {
            frame = 0;
        }
        if (frame >= 0 && frame < sprites.Length)
        {
            spriteRenderer.sprite = sprites[frame];
        }
    }
}
