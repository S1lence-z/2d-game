using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerUpStatus : MonoBehaviour
{
    [SerializeField] private Image doubleJumpImage;
    public bool doubleJumpStatus { get; private set; } = false;

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