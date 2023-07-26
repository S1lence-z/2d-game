using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D playerBody;
    private Animator anim;
    private float dirX = 0f;

    // Start is called before the first frame update
    void Start()
    {
        playerBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal");
        // the multiplication ensures joystick support as the value can vary
        playerBody.velocity = new Vector2(dirX * 7f, playerBody.velocity.y);

        if (Input.GetButtonDown("Jump"))
        {
            playerBody.velocity = new Vector2(playerBody.velocity.x, 14f);
        }
        AnimationUpdate();
    }

    private void AnimationUpdate()
    {
        // animatior transition from idle to running and vice versa
        if (dirX > 0f)
        {
            anim.SetBool("running", true);
        }
        else if (dirX < 0f)
        {
            anim.SetBool("running", true);
        }
        else
        {
            anim.SetBool("running", false);
        }
    }
}
