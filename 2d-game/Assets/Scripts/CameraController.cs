using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform player;

    private void Update()
    {
        // it takes the new position of x and y but the z position remains the same simply put the camera does not rotate with the player
        transform.position = new Vector3(player.position.x, player.position.y, transform.position.z);
    }
}
