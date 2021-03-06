﻿//Reginald Ashman 2015
using UnityEngine;
using UnityEngine.UI;
using System.Collections;



public class GameLogicManager : MonoBehaviour
{

    public delegate void OnPlayerIsDead();
    public static event OnPlayerIsDead playerIsDead;

    public Button pause;
    public ObstacleSpawner obstacleSpawner1;
    private float scoreToAddEverySecond = 5.0f;
    private float increaseInSpawnSpeedPerSecond = 7.0f;
    private Player player = null;
    private Score score = null;
    private Timer timer = null;
    
    // Use this for initialization
    void Start()
    {
        player = FindObjectOfType<Player>();
        score = FindObjectOfType<Score>();
        timer = FindObjectOfType<Timer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player.IsAlive)
        {
            score.AddScore(scoreToAddEverySecond * Time.deltaTime);
            if (obstacleSpawner1 != null)
            {
                obstacleSpawner1.IncreaseSpawnSpeed(increaseInSpawnSpeedPerSecond * Time.deltaTime);
            }

            // Doubles the player's score
            if (player.ScoreMultiplierEnabled)
            {
                score.AddScore(score.PlayerScore * 2.0f);
                player.ScoreMultiplierEnabled = false;
            }


        }
        else
        {
            GameOver();
        }
    }

    private void GameOver()
    {
        pause.gameObject.SetActive(false);
        SaveHighScore();
        //Debug.Log("Game Over");
        if (playerIsDead != null)
        {
            playerIsDead();
        }
    }

    private void SaveHighScore()
    {
        if (score != null)
        {
            if (score.PlayerScore > PlayerPrefs.GetFloat(Utilities.PlayerPrefsHighScoreString))
            {
                PlayerPrefs.SetFloat(Utilities.PlayerPrefsHighScoreString, score.PlayerScore);
            }
        }
        else
        {
            Debug.LogError("Score is null.");
        }
    }
}