using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalSettings : MonoBehaviour
{
    public static string[] gameModes = { "levels", "infinite" };
    public static string chosenGameMode;

    public void SetGameMode(int gameModeIndex)
    {
        chosenGameMode = gameModes[gameModeIndex];
    }
}