using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerLife : MonoBehaviour
{
    private Animator anim;
    private Rigidbody2D rigidBody;
    private BoxCollider2D boxCollider;
    private bool isDead = false;
    private int totalHp = 3;
    private string currentSceneName;
    [SerializeField] private float deathDelay = 2f;
    [SerializeField] private Text displayHp;

    private void Start()
    {
        anim = GetComponent<Animator>();
        rigidBody = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
        currentSceneName = SceneManager.GetActiveScene().name;
    }

    private void Update()
    {
        if (isDead)
        {
            rigidBody.velocity = Vector2.zero;
            rigidBody.gravityScale = 0f;
            if (boxCollider != null)
            {
                Destroy(boxCollider);
            }
        }
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
        UpdateHp();
        anim.SetTrigger("death");
        if (totalHp <= 0)
        {
            StartCoroutine(LoadSceneWithDelay("Start Screen"));
            return;
        }
        else
        {
            StartCoroutine(LoadSceneWithDelay(currentSceneName));
            return;
        }
    }

    private void UpdateHp()
    {
        totalHp--;
        displayHp.text = "HP: " + totalHp.ToString();
    }

    private IEnumerator LoadSceneWithDelay(string sceneName)
    {
        yield return new WaitForSeconds(deathDelay);
        SceneManager.LoadScene(sceneName);
    }

}
