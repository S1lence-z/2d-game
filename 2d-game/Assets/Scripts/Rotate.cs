using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    [SerializeField] private float rotateSpeed = 2f; // It is in degrees
    private void Update()
    {
        transform.Rotate(0, 0, rotateSpeed * 360 * Time.deltaTime);
        // This rotates the image by 360 degrees times speed per second (frame by frame)
    }
}
