using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SurpriseBox : MonoBehaviour
{
    [SerializeField] private GameObject powerUpObject;
    private bool alreadyUsed = false;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!alreadyUsed && collision.gameObject.CompareTag("Player"))
        {
            if (collision.transform.DirectionTest(transform, Vector2.up))
            {
                Instantiate(powerUpObject, transform.position + new Vector3(0, 2, 0), Quaternion.identity);
            }
        }
    }
}
