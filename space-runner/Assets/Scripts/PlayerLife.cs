using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerLife : MonoBehaviour
{
    // Game Objects
    private GameObject player;
    private Animator anim;
    private PlayerMovement movement;
    private Rigidbody2D rigidBody;
    private BoxCollider2D boxCollider;
    public PlayerSpriteRenderer smallRenderer;
    public PlayerSpriteRenderer bigRenderer;
    private PlayerSpriteRenderer activeRenderer;
    
    // Variables
    private float deathDelay = 2f;
    private bool isDead = false;
    private bool isBig = false;
    private static int totalHp;
    private Vector3 startPos;
    [SerializeField] private Text displayHP;
    [SerializeField] private AudioSource deathSFX;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        anim = GetComponent<Animator>();
        rigidBody = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
        movement = GetComponent<PlayerMovement>();
        startPos = player.transform.position;
        totalHp = 3;
    }

    private void DisablePhysics()
    {
        movement.enabled = false;
        boxCollider.enabled = false;
        rigidBody.velocity = Vector3.zero;
        rigidBody.gravityScale = 0f;
    }

    private void EnablePhysics()
    {
        movement.enabled = true;
        boxCollider.enabled = true;
        rigidBody.gravityScale = 3f;
    }

    private void Update()
    {
        if (isDead)
        {
            DisablePhysics();
        }
        displayHP.text = "HP: " + totalHp.ToString();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!isDead && collision.gameObject.CompareTag("Trap"))
        {
            Hit();
        }
    }

    private void Hit()
    {
        if (isBig)
        {
            ShrinkPlayer();
        }
        else
        {
            Die();
        }
    }

    private void Die()
    {
        deathSFX.Play();
        DisablePhysics();
        isDead = true;
        DecreaseHp();
        if (anim != null)
        {
            anim.SetTrigger("death");
        }

        if (totalHp <= 0)
        {
            StartCoroutine(Extensions.LoadSceneWithDelayByName("Game Over", deathDelay));
            return;
        }
        else {
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
        if (anim != null)
        {
            anim.ResetTrigger("death");
        }

        if (anim != null)
        {
            anim.Play("Player_Idle");
        }
        EnablePhysics();
        player.transform.position = startPos;
    }

    public void EnableBigPlayer()
    {
        GrowPlayer();
    }

    public void DisableBigPlayer()
    {
        ShrinkPlayer();
    }

    private void GrowPlayer()
    {
        isBig = true;
        smallRenderer.enabled = false;
        bigRenderer.enabled = true;
        activeRenderer = bigRenderer;
        boxCollider.size = new Vector2(1.25f, 2f);
        boxCollider.offset = new Vector2(boxCollider.offset.x, -.4f);
    }

    private void ShrinkPlayer()
    {
        isBig = false;
        smallRenderer.enabled = true;
        bigRenderer.enabled = false;
        activeRenderer = smallRenderer;
        boxCollider.size = new Vector2(0.8529136f, 1.27851f);
        boxCollider.offset = new Vector2(boxCollider.offset.x, -0.7326109f);
    }
}