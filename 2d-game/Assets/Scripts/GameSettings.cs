using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameSettings : MonoBehaviour
{
    // Chosen Game Mode
    public enum GameMode
    {
        Levels,
        Infinite
    }
    public static GameMode ChosenGameMode { get; private set; }

    public static bool DoubleJump { get; private set; } = false;

    public static void SetGameMode(GameMode mode)
    {
        ChosenGameMode = mode;
    }
}