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
    private bool callUpdate = false;
    private bool movingRight = false;
    private Vector3 prevPos;
    private Vector3 currPos;

    private void Start()
    {
        body = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        prevPos = Vector3.zero;
        currPos = transform.position;
    }

    private void Update()
    {
        if (callUpdate)
        {
            Move(horizontalForce, verticalForce);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (verticalForce <= .1f)
        {
            callUpdate = true;
        }
        else
        {
            Move(horizontalForce, verticalForce);
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        UpdatePositions();
        if (prevPos == currPos)
        {
            TurnAround();
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

    private void Move(float forceX, float forceY)
    {
        body.velocity = new Vector2(forceX * (movingRight ? 1 : -1), forceY);
    }

    private void TurnAround()
    {
        movingRight = !movingRight;
        sprite.flipX = !sprite.flipX;
    }

    private void UpdatePositions()
    {
        prevPos = currPos;
        currPos = transform.position;
    }
}
