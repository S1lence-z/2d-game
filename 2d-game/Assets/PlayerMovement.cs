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
        AnimationUpdate();
    }

    private void AnimationUpdate()
    {
        // animatior transition from idle to running and vice versa
        if (dirX > 0f) // when running right
        {
            anim.SetBool("running", true);
            sprite.flipX = false;
        }
        else if (dirX < 0f) // when running left
        {
            anim.SetBool("running", true);
            sprite.flipX = true;
        }
        else
        {
            anim.SetBool("running", false);
        }
    }
}
