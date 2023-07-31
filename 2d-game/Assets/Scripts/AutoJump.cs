using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoJump : MonoBehaviour
{
    private BoxCollider2D boxCollider;
    private Rigidbody2D body;
    [SerializeField] private float jumpForce = 30f;
    [SerializeField] private float horizontalForce = 5f;
    [SerializeField] private LayerMask jumpableGround;

    // Start is called before the first frame update
    private void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        body = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (IsGrounded())
        {
            Jump(jumpForce);
            MoveHorizontally(horizontalForce);
        }
    }

    private bool IsGrounded()
    {
        return Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }

    private void Jump(float force)
    {
        body.AddForce(Vector2.up * force);
    }

    private void MoveHorizontally(float force)
    {
        body.AddForce(Vector2.right * force);
    }
}
