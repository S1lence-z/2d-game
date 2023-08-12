using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalSettings : MonoBehaviour
{
    public static string[] gameModes = { "levels", "infinite" };
    public static string chosenGameMode;
    public static int currentScore = 0;
    public static int highScore = 0;

    public void SetGameMode(int gameModeIndex)
    {
        chosenGameMode = gameModes[gameModeIndex];
    }
}