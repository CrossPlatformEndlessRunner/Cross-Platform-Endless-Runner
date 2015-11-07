using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Score : MonoBehaviour
{
    
    public string defaultScoreText = "Score: ";
    private Text scoreText;
    private float playerScore = 0;
    private bool isGameOver = false;

    // Use this for initialization
    void Start()
    {
        scoreText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = defaultScoreText + playerScore.ToString("F0");
    }

    public void AddScore(float scoreToAdd)
    {
        playerScore += scoreToAdd;
    }

    public void ResetScore()
    {
        playerScore = 0.0f;
    }

    public float PlayerScore
    {
        get { return playerScore; }
        set { playerScore = value; }
    }
}