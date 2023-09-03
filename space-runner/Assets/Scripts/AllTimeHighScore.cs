using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AllTimeHighScore : MonoBehaviour
{
    // SerializeField attribute makes private variables visible in the Unity Inspector.
    [SerializeField] private Text levelsHighScore;   // Reference to a UI Text component for levels high score.
    [SerializeField] private Text infiniteHighScore; // Reference to a UI Text component for infinite high score.

    // Static variables to store the highest scores for levels and infinite modes.
    private static int levelsHS;
    private static int infiniteHS;

    // This method is called when the object this script is attached to is created.
    private void Awake()
    {
        // Initialize the static high score variables with the current high scores.
        levelsHS = GameScore.highScore;           // Get the high score for levels mode.
        infiniteHS = InfiniteGameScore.highScore; // Get the high score for infinite mode.
    }

    // This method is called once per frame.
    private void Update()
    {
        // Call two methods: GetHighScores() and UpdateHighScores().
        GetHighScores();    // Update the high score variables if needed.
        UpdateHighScores(); // Update the UI Text components with the high scores.
    }

    // This method checks if the current game's high score surpasses the stored high score.
    private void GetHighScores()
    {
        // Check if the current levels high score is greater than the stored high score.
        if (GameScore.highScore > levelsHS)
        {
            levelsHS = GameScore.highScore; // Update the levels high score.
        }

        // Check if the current infinite high score is greater than the stored high score.
        if (InfiniteGameScore.highScore > infiniteHS)
        {
            infiniteHS = InfiniteGameScore.highScore; // Update the infinite high score.
        }
    }

    // This method updates the UI Text components to display the current high scores.
    private void UpdateHighScores()
    {
        // Update the text for the levels high score UI element.
        levelsHighScore.text = "Levels HS: " + levelsHS.ToString();

        // Update the text for the infinite high score UI element.
        infiniteHighScore.text = "Infinite HS: " + infiniteHS.ToString();
    }
}
