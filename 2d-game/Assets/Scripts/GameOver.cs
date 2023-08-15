using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public void GoToStartMenu()
    {
        SceneManager.LoadScene("Start Screen");
        ResetScoreCounter();
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void PlayAgain()
    {
        if (GlobalSettings.chosenGameMode == GlobalSettings.gameModes[0])
        {
            StartGame.StartLevelsMode();
        }
        else if (GlobalSettings.chosenGameMode == GlobalSettings.gameModes[1])
        {
            StartGame.StartInfiniteMode();
        }
        ResetScoreCounter();
    }

    private void ResetScoreCounter()
    {
        GlobalSettings.ResetScoreCount();
    }
}
