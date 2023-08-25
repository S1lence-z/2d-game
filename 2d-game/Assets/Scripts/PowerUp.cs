using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerUp : MonoBehaviour
{
    public enum Type
    {
        HealingOrb,
        DoubleJump,
        ScoreItem,
        Invincibility
    }

    public Type type;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Collect();
        }
    }

    private void Collect()
    {
        switch(type)
        {
            case Type.HealingOrb:
                PlayerLife.IncreaseHp();
                break;

            case Type.DoubleJump:
                if (GameSettings.ChosenGameMode == GameSettings.GameMode.Levels) 
                {
                    PlayerMovement.EnableDoubleJump();
                }
                else
                {
                    InfinitePlayerMovement.EnableDoubleJump();
                }
                break;

            case Type.Invincibility:
                if (GameSettings.ChosenGameMode == GameSettings.GameMode.Levels)
                {
                    PlayerLife.EnableInvinciblePlayer();
                }
                else
                {
                    InfinitePlayerLife.EnableInvinciblePlayer();
                }
                break;

            case Type.ScoreItem:
                if (GameSettings.ChosenGameMode == GameSettings.GameMode.Levels) 
                {
                    GameScore.AddScore();
                }
                else
                {
                    InfiniteGameScore.AddScore();
                }
                break;
        }
        Destroy(gameObject);
    }
}
