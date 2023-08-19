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
        ScoreItem
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
                if (GlobalSettings.chosenGameMode == "levels")
                {
                    PlayerMovement.EnableDoubleJump();
                }
                else
                {
                    InfinitePlayerMovement.EnableDoubleJump();
                }
                break;

            case Type.ScoreItem:
                GlobalSettings.AddScore();
                break;
        }
        Destroy(gameObject);
    }
}
