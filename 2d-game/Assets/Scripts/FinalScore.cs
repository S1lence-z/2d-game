using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinalScores : MonoBehaviour
{
    [SerializeField] private Text displayCurrentScore;
    [SerializeField] private Text displayHighScore;

    private void Update()
    {
        UpdateHighScore();
        displayCurrentScore.text = "Current Score: " + GlobalSettings.currentScore.ToString();
        displayHighScore.text = "High Score: " + GlobalSettings.highScore.ToString();
    }

    private void UpdateHighScore()
    {
        if (GlobalSettings.currentScore > GlobalSettings.highScore)
        {
            GlobalSettings.highScore = GlobalSettings.currentScore;
        }
    }
}
