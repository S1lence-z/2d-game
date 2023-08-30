using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUpEffect : MonoBehaviour
{
    [SerializeField] private float moveDelay = .09f;
    private Vector3 position_1;
    private Vector3 position_2;

    private void Start()
    {
        position_1 = transform.position;
        position_2 = position_1 + new Vector3(0, 1, 0);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (collision.transform.DirectionTest(transform, Vector2.up))
            {
                StartCoroutine(MoveUpAndDown());
            }
        }
    }

    private IEnumerator MoveUpAndDown()
    {
        StartCoroutine(MoveGradually(moveDelay, position_1, position_2));
        yield return new WaitForSeconds(moveDelay);
        StartCoroutine(MoveGradually(moveDelay, position_2, position_1));
    }

    private IEnumerator MoveGradually(float delay, Vector3 startingPos, Vector3 targetPos)
    {
        float elapsedTime = 0f;

        while (elapsedTime < delay)
        {
            transform.position = Vector3.Lerp(startingPos, targetPos, elapsedTime / delay);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
    }
}