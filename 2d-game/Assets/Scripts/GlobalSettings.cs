using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GlobalSettings : MonoBehaviour
{
    public static string[] gameModes = { "levels", "infinite" };
    public static string chosenGameMode;

    public static void SetGameMode(int gameModeIndex)
    {
        chosenGameMode = gameModes[gameModeIndex];
    }
}