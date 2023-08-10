using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrampolineJump : MonoBehaviour
{
    private GameObject player;
    private Rigidbody2D playerBody;
    private Animator anim;
    [SerializeField] private float launchForce;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerBody = player.GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            anim.SetBool("trampOn", true);
            playerBody.velocity = Vector2.up * launchForce;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        anim.SetBool("trampOn", false);
    }
}
