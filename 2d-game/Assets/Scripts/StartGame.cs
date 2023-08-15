using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public static void StartLevelsMode()
    {
        SceneManager.LoadScene("Level 1");
        GlobalSettings.SetGameMode(0);
    }

    public static void StartInfiniteMode()
    {
        print("To be implemented!");
        GlobalSettings.SetGameMode(1);
    }
}