using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoJump : MonoBehaviour
{
    private BoxCollider2D boxCollider;
    private Rigidbody2D body;
    [SerializeField] private float jumpForce = 30f;
    [SerializeField] private float toLeftForce = 0f;
    [SerializeField] private LayerMask jumpableGround;

    // Start is called before the first frame update
    private void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (isGrounded())
        {
            body.AddForce(Vector2.up * jumpForce);
            body.AddForce(Vector2.left * toLeftForce);
        }
    }

    public bool isGrounded()
    {
        return Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }
}
