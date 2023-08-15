using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public enum Type
    {
        HealingOrb,
        DoubleJump
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
                PlayerMovement.EnableDoubleJump();
                break;
        }
        Destroy(gameObject);
    }
}
