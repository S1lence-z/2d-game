using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{
    public void GoToStartMenu()
    {
        SceneManager.LoadScene("Start Screen");
        ResetAllSettings();
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void PlayAgain()
    {
        if (GameSettings.ChosenGameMode == GameSettings.GameMode.Levels)
        {
            StartGame.StartLevelsMode();
        }
        else if (GameSettings.ChosenGameMode == GameSettings.GameMode.Infinite)
        {
            StartGame.StartInfiniteMode();
        }
        ResetAllSettings();
    }
    private void ResetAllSettings()
    {
        // Reset All Score Counters
        GameScore.ResetScoreCount();
        InfiniteGameScore.ResetScoreCount();
        // Reset Power Ups
        PlayerMovement.DisableDoubleJump();
        InfinitePlayerMovement.DisableDoubleJump();
    }
}
