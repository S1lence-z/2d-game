using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FanController : MonoBehaviour
{
    private GameObject player;
    private Rigidbody2D playerRb;
    [SerializeField] private float windForce = 25f;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerRb = player.GetComponent<Rigidbody2D>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Vector2 fanDirection = transform.up.normalized;
            playerRb.AddForce(fanDirection * windForce);
        }
    }
}
