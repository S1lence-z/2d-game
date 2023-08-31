using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public static void StartLevelsMode()
    {
        SceneManager.LoadScene("Level 1");
        GameSettings.SetGameMode(GameSettings.GameMode.Levels);
    }

    public static void StartInfiniteMode()
    {
        SceneManager.LoadScene("Infinite Level");
        GameSettings.SetGameMode(GameSettings.GameMode.Infinite);
    }
}