using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerUp : MonoBehaviour
{
    private GameObject player;
    private PlayerLife life;
    private PowerUpStatus powerStatus;

    public enum Type
    {
        HealingOrb,
        DoubleJump,
        ScoreItem,
        BigPlayer
    }

    public Type type;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        life = player.GetComponent<PlayerLife>();
        powerStatus = player.GetComponent<PowerUpStatus>();
    }

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
                    powerStatus.UpdateDoubleJumpState();
                    PlayerMovement.EnableDoubleJump();
                }
                else
                {
                    InfinitePlayerMovement.EnableDoubleJump();
                }
                break;

            case Type.BigPlayer:
                if (GameSettings.ChosenGameMode == GameSettings.GameMode.Levels)
                {
                    life.EnableBigPlayer();
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
