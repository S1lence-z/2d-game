using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D playerBody;

    // Start is called before the first frame update
    void Start()
    {
        playerBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float dirX = Input.GetAxisRaw("Horizontal");
        // the multiplication ensures joystick support as the value can vary
        playerBody.velocity = new Vector2(dirX * 7f, playerBody.velocity.y);

        if (Input.GetButtonDown("Jump"))
        {
            playerBody.velocity = new Vector2(playerBody.velocity.x, 14f);
        }
    }
}
