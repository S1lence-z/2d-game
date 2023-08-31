using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerUpStatus : MonoBehaviour
{
    [SerializeField] private Image doubleJumpImage;
    public static bool doubleJumpStatus { get; private set; } = false;

    private void Update()
    {
        CheckDoubleJumpState();
    }

    public static void ResetDoubleJumpState()
    {
        doubleJumpStatus = false;
    }

    private void CheckDoubleJumpState()
    {
        if (doubleJumpStatus)
        {
            DoubleJumpOn();
        }
        else
        {
            DoubleJumpOff();
        }
    }

    public void UpdateDoubleJumpState()
    {
        doubleJumpStatus = !doubleJumpStatus;
        if (doubleJumpStatus)
        {
            DoubleJumpOn();
        }
        else
        {
            DoubleJumpOff();
        }
    }

    private void DoubleJumpOn()
    {
        doubleJumpImage.color = Color.green;
    }

    private void DoubleJumpOff()
    { 
        doubleJumpImage.color = Color.red;
    }
}