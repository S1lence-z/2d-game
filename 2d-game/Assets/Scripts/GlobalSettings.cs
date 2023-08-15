using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GlobalSettings : MonoBehaviour
{
    [SerializeField] private Text displayScore;
    public static string[] gameModes = { "levels", "infinite" };
    public static string chosenGameMode;
    public static int currentScore = 0;
    public static int highScore = 0;

    private void Update()
    {
        UpdateDisplayScore();
        UpdateHighScore();
    }

    public static void SetGameMode(int gameModeIndex)
    {
        chosenGameMode = gameModes[gameModeIndex];
    }

    private void UpdateHighScore()
    {
        if (currentScore > highScore)
        {
            highScore = currentScore;
        }
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