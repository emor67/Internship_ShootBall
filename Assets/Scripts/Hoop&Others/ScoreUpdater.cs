using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreUpdater : MonoBehaviour
{
    public TextMeshPro scoreText; // Text for the current score display
    public float score;               // The current score
    public BallPool ballPool;   // Reference to the BallManager script that holds the list
    public float _ballScore;           // The score value from the ball object

    void Start()
    {
        UpdateBallScore();  // Initialize the ballScore from the first ball in the list
        UpdateScoreText();
    }

    // Continuously updates the score based on the first ball's text in FixedUpdate
    void FixedUpdate()
    {
        UpdateBallScore();  // Continuously update the ballScore from the first element
    }

    private void UpdateBallScore()
    {
        GameObject firstBall = ballPool.Balls[0]; // Access the first ball in the list
        TextMeshPro ballText = firstBall.GetComponentInChildren<TextMeshPro>();

        //Convert the text in the TextMeshPro to a float and assign it to ballScore
        float.TryParse(ballText.text, out _ballScore);  
    }

    // This is triggered when the player collides with the hoop
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") /*&& ballPool.decreasable*/)
        {
            DecreaseScore();
        }
    }

    // Decreases the score and updates the UI text
    public void DecreaseScore()
    {
        score -= _ballScore; // Decrease the score by the ball's score value
        UpdateScoreText();
        if(score<=0){
            Destroy(gameObject);
        }
    }

    // Updates the score text on the UI
    void UpdateScoreText()
    {
        scoreText.text = score.ToString();
    }
}
