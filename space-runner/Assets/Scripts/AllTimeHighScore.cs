using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AllTimeHighScore : MonoBehaviour
{
    [SerializeField] private Text levelsHighScore;
    [SerializeField] private Text infiniteHighScore;
    private static int levelsHS;
    private static int infiniteHS;

    private void Awake()
    {
        levelsHS = GameScore.highScore;
        infiniteHS = InfiniteGameScore.highScore;
    }

    private void Update()
    {
        GetHighScores();
        UpdateHighScores();
    }

    private void GetHighScores()
    {
        if (GameScore.highScore > levelsHS)
        {
            levelsHS = GameScore.highScore;
        }
        if (InfiniteGameScore.highScore > infiniteHS)
        {
            infiniteHS = InfiniteGameScore.highScore;
        }
    }

    private void UpdateHighScores()
    {
        levelsHighScore.text = "Levels HS: " + levelsHS.ToString();
        infiniteHighScore.text = "Infinite HS: " + infiniteHS.ToString();
    }
}
