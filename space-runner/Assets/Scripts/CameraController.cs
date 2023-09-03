using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Transform player; // Reference to the player's Transform component.

    // This method is called when the script instance is initialized.
    private void Awake()
    {
        // Find the GameObject with the "Player" tag and get its Transform component.
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // This method is called in the LateUpdate phase, ensuring it runs after player movement.
    private void LateUpdate()
    {
        // Set the camera's position to match the player's X and Y position, maintaining its Z position.
        transform.position = new Vector3(player.position.x, player.position.y, transform.position.z);
    }
}
