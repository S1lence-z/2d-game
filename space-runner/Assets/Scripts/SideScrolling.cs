using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideScrolling : MonoBehaviour
{
    [SerializeField] private Transform player;

    private void LateUpdate()
    {
        Vector3 cameraPostion = transform.position;
        cameraPostion.x = Mathf.Max(cameraPostion.x, player.position.x);
        cameraPostion.y = player.position.y;
        transform.position = cameraPostion;
    }
}
