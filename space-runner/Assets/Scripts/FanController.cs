using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FanController : MonoBehaviour
{
    [SerializeField] private GameObject player;
    private Rigidbody2D playerRb;
    [SerializeField] private float windForce = 25f;
    [SerializeField] private bool vectorUp = true;
    private Vector2 fanDirection;

    private void Start()
    {
        playerRb = player.GetComponent<Rigidbody2D>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PushPlayer();
        }
    }

    private void PushPlayer()
    {
        if (vectorUp)
        {
            fanDirection = transform.up.normalized;
            playerRb.AddForce(fanDirection * windForce);
        }
        else
        {
            fanDirection = -transform.up.normalized;
            playerRb.AddForce(fanDirection * windForce);
        }
    }
}
