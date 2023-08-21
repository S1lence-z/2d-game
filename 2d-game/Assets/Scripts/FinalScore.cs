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
        if (GlobalSettings.chosenGameMode == "levels")
        {
            displayCurrentScore.text = "Current Score: " + GameScore.currentScore.ToString();
            displayHighScore.text = "High Score: " + GameScore.highScore.ToString();
        }
        else
        {
            displayCurrentScore.text = "Current Score: " + GameScoreInfinite.currentScore.ToString();
            displayHighScore.text = "High Score: " + GameScoreInfinite.highScore.ToString();
        }
    }
}
