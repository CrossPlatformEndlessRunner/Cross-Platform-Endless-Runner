using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameOverMenuManager : MonoBehaviour
{
    public Canvas gameOverCanvas;
    public Text yourScore;
    public Text currentHighScore;
    private Score score = null;

    // Use this for initialization
    void Start()
    {
        if (gameOverCanvas != null)
        {
            gameOverCanvas.enabled = false;
        }
        score = FindObjectOfType<Score>();

        
    }
    void OnEnable()
    {
        GameLogicManager.playerIsDead += PlayerDeath;
    }

    void OnDisable()
    {
        GameLogicManager.playerIsDead -= PlayerDeath;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void PlayerDeath()
    {
        gameOverCanvas.enabled = true;
        currentHighScore.text = PlayerPrefs.GetFloat(Utilities.PlayerPrefsHighScoreString).ToString("F0");
        if (score != null)
        {
            yourScore.text = score.PlayerScore.ToString("F0");
        }
        else
        {
            Debug.LogError("Score is null");
        }
    }

    public void PlayAgainButton()
    {
        Application.LoadLevel(Application.loadedLevel);
    }

    public void BackToMenuButton()
    {
        Application.LoadLevel((int)Utilities.LEVEL_NUMS.MAIN_MENU);
    }
}