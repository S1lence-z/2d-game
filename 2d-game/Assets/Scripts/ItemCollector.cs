using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollector : MonoBehaviour
{
    private int scoreCount = 0;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the player has collided with a score item, an object that represents the in-game score
        if (collision.gameObject.CompareTag("Score Item"))
        {
            Destroy(collision.gameObject);
            scoreCount++;
        }
    }
}
