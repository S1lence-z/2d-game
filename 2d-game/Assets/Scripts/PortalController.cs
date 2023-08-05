using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PortalController : MonoBehaviour
{
    [SerializeField] private Transform targetPortal;
    private GameObject player;
    private Animator anim;
    private Rigidbody2D rigidBody;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        anim = player.GetComponent<Animator>();
        rigidBody = player.GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (Vector2.Distance(player.transform.position, transform.position) > .3f)
            {
                StartCoroutine(PortalIn());
            }
        }
    }

    IEnumerator PortalIn()
    {
        rigidBody.simulated = false;
        anim.Play("Player_Portal_In");
        StartCoroutine(MoveInPortal());
        yield return new WaitForSeconds(0.5f);
        player.transform.position = targetPortal.position;
        rigidBody.velocity = Vector2.zero;
        anim.Play("Player_Portal_Out");
        yield return new WaitForSeconds(0.5f);
        anim.Play("Player_Idle");
        rigidBody.simulated = true;
    }

    IEnumerator MoveInPortal()
    {
        float timer = 0;
        while (timer < 0.5f)
        {
            player.transform.position = Vector2.MoveTowards(player.transform.position, transform.position, 3 * Time.deltaTime);
            yield return new WaitForEndOfFrame();
            timer += Time.deltaTime;
        }
    }

}
