using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public void GoToStartMenu()
    {
        SceneManager.LoadScene("Start Screen");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
