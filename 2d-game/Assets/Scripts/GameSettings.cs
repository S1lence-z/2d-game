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

    // Power Up States
    public enum PowerUpType
    {
        DoubleJump,
    }
    public static bool DoubleJump { get; private set; } = false;

    public static void SetGameMode(GameMode mode)
    {
        ChosenGameMode = mode;
    }

    public static void SetPowerUpStatus(PowerUpType powerUp)
    {
        switch (powerUp)
        {
            case PowerUpType.DoubleJump:
                DoubleJump = !DoubleJump;
                break;
        }
    }
}