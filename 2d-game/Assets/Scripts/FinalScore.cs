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
        if (GameSettings.ChosenGameMode == GameSettings.GameMode.Levels)
        {
            displayCurrentScore.text = "Current Score: " + GameScore.currentScore.ToString();
            displayHighScore.text = "High Score: " + GameScore.highScore.ToString();
        }
        else
        {
            displayCurrentScore.text = "Current Score: " + InfiniteGameScore.currentScore.ToString();
            displayHighScore.text = "High Score: " + InfiniteGameScore.highScore.ToString();
        }
    }
}
