using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerLife : MonoBehaviour
{
    private GameObject player;
    private Animator anim;
    private Rigidbody2D rigidBody;
    private BoxCollider2D boxCollider;
    private float deathDelay = 2f;
    private bool isDead = false;
    private static int totalHp;
    private Vector3 startPos;
    [SerializeField] private Text displayHP;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        anim = GetComponent<Animator>();
        rigidBody = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
        startPos = player.transform.position;
        totalHp = 3;
    }

    private void Update()
    {
        if (isDead)
        {
            rigidBody.velocity = Vector2.zero;
            rigidBody.gravityScale = 0f;
            if (boxCollider != null)
            {
                boxCollider.enabled = false;
            }
        }
        displayHP.text = "HP: " + totalHp.ToString();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!isDead && collision.gameObject.CompareTag("Trap"))
        {
            Die();
        }
    }

    private void Die()
    {
        isDead = true;
        DecreaseHp();
        anim.SetTrigger("death");
        if (totalHp <= 0)
        {
            StartCoroutine(Extensions.LoadSceneWithDelayByName("Game Over", deathDelay));
            return;
        }
        else
        {
            StartCoroutine(RespawnPlayer());
            return;
        }
    }

    private void DecreaseHp()
    {
        totalHp--;
    }

    public static void IncreaseHp()
    {
        totalHp++;
    }

    private IEnumerator RespawnPlayer()
    {
        yield return new WaitForSeconds(deathDelay);
        isDead = false;
        anim.ResetTrigger("death");
        boxCollider.enabled = true;
        rigidBody.gravityScale = 3f;
        anim.Play("Player_Idle");
        player.transform.position = startPos;
    }

    public static void EnableInvinciblePlayer()
    {
        GameSettings.SetPowerUpStatus(GameSettings.PowerUpType.Invincibility);
        // Changed the scale of the player model and change the hitbox size
    }
}
