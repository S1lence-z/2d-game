using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMovement
{
    public enum PlayerMovementState
    {
        idle,
        running,
        jumping,
        falling,
        doubleJumping
    };

    bool IsEnabled { get; }

    PlayerMovementState State { get; }
}
