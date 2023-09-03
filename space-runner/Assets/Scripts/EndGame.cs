using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{
    // This method is called when the "Go To Start Menu" button is clicked.
    public void GoToStartMenu()
    {
        SceneManager.LoadScene("Start Screen"); // Load the "Start Screen" scene.
        ResetAllSettings(); // Reset various game settings and scores.
    }

    // This method is called when the "Exit Game" button is clicked.
    public void ExitGame()
    {
        Application.Quit(); // Quit the game application.
    }

    // This method is called when the "Play Again" button is clicked.
    public void PlayAgain()
    {
        // Check the chosen game mode and start the corresponding game mode.
        if (GameSettings.ChosenGameMode == GameSettings.GameMode.Levels)
        {
            StartGame.StartLevelsMode();
        }
        else if (GameSettings.ChosenGameMode == GameSettings.GameMode.Infinite)
        {
            StartGame.StartInfiniteMode();
        }
        ResetAllSettings(); // Reset various game settings and scores.
    }

    // This private method is used to reset various game settings and scores.
    private void ResetAllSettings()
    {
        // Reset All Score Counters
        GameScore.ResetScoreCount(); // Reset the score counter for levels mode.
        InfiniteGameScore.ResetScoreCount(); // Reset the score counter for infinite mode.
        // Reset Power Ups
        PlayerMovement.DisableDoubleJump(); // Disable double jump power-up for levels mode.
        InfinitePlayerMovement.DisableDoubleJump(); // Disable double jump power-up for infinite mode.
        PowerUpStatus.ResetDoubleJumpState(); // Reset the double jump power-up state.
    }
}
