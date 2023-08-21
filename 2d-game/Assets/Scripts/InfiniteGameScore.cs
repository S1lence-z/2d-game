using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfiniteGameScore : MonoBehaviour
{
    [SerializeField] private Text displayScore;
    public static int currentScore = 0;
    public static int highScore = 0;

    private void Update()
    {
        UpdateDisplayScore();
        UpdateHighScore();
    }

    private void UpdateHighScore()
    {
        highScore = (currentScore > highScore) ? currentScore : highScore;
    }

    private void UpdateDisplayScore()
    {
        displayScore.text = "Score: " + currentScore.ToString();
    }

    public static void ResetScoreCount()
    {
        currentScore = 0;
    }

    public static void AddScore()
    {
        currentScore++;
    }
}
