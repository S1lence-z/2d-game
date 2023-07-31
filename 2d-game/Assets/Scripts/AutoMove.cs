using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoMove : MonoBehaviour
{
    private Rigidbody2D body;
    [SerializeField] private float verticalForce = 5f;
    [SerializeField] private float horizontalForce = 0f;

    // Start is called before the first frame update
    private void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Terrain")
        {
            Move(horizontalForce, verticalForce);
        }
    }

    private void Move(float forceX, float forceY)
    {
        body.velocity = new Vector2(forceX, forceY);
    }
}
