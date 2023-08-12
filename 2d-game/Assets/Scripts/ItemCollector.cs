using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    private int scoreCount = 0;
    [SerializeField] private Text displayScore;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the player has collided with a score item, an object that represents the in-game score
        if (collision.gameObject.CompareTag("Score Item"))
        {
            Destroy(collision.gameObject);
            scoreCount++;
            displayScore.text = "Score: " + scoreCount.ToString();
        }
    }

    private void Update()
    {
        SetScoreGlobally();
    }

    private void SetScoreGlobally()
    {
        GlobalSettings.currentScore = scoreCount;
    }
}
