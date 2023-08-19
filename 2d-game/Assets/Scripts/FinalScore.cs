using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinalScore : MonoBehaviour
{
    [SerializeField] private Text displayCurrentScore;
    [SerializeField] private Text displayHighScore;

    private void Start()
    {
        displayCurrentScore.text = "Current Score: " + GameScore.currentScore.ToString();
        displayHighScore.text = "High Score: " + GameScore.highScore.ToString();
    }
}
