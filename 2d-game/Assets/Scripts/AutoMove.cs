using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoMove : MonoBehaviour
{
    private Rigidbody2D body;
    [SerializeField] private float verticalForce;
    [SerializeField] private float horizontalForce;
    private bool callUpdate = false;

    // Start is called before the first frame update
    private void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (callUpdate)
        {
            Move(horizontalForce, verticalForce);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (verticalForce <= .1f)
        {
            callUpdate = true;
        }
        else
        {
            Move(horizontalForce, verticalForce);
        }
    }

    private void Move(float forceX, float forceY)
    {
        body.velocity = new Vector2(forceX, forceY);
    }
}
