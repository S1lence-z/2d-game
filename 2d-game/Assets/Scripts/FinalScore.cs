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
        GlobalSettings.UpdateHighScore();
        displayCurrentScore.text = "Current Score: " + GlobalSettings.currentScore.ToString();
        displayHighScore.text = "High Score: " + GlobalSettings.highScore.ToString();
    }
}
