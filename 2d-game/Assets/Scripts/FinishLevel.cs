using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLevel : MonoBehaviour
{
    private bool levelCompleted = false;
    private int lastLevelIndex = 4;
    private float winDelay = 2f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!levelCompleted && collision.gameObject.name == "Player")
        {
            print("You Completed This Level!");
            levelCompleted = true;
        }
    }

    private void CompleteLevel()
    {
        int activeSceneIndex = SceneManager.GetActiveScene().buildIndex;
        if (activeSceneIndex == lastLevelIndex) {
            StartCoroutine(Extensions.LoadSceneWithDelayByName("Game Won", winDelay));
        }
        else {
            StartCoroutine(Extensions.LoadSceneWithDelayByIndex(SceneManager.GetActiveScene().buildIndex + 1, winDelay));
        }
    }
}
