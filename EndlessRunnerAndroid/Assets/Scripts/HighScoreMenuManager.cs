using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HighScoreMenuManager : MonoBehaviour
{
    public Canvas mainMenuCanvas;
    public Canvas highScoreMenuCanvas;
    public Text highScoreText;
    private float displayedHighScore = 0.0f;

    // Use this for initialization
    void Start()
    {
        if (highScoreMenuCanvas != null)
        {
            highScoreMenuCanvas.enabled = false;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        float newHighScore = PlayerPrefs.GetFloat(Utilities.PlayerPrefsHighScoreString);
        if (displayedHighScore != newHighScore)
        {
            displayedHighScore = newHighScore;
        }
        highScoreText.text = displayedHighScore.ToString("F0");
    }

    public void BackToMainMenu()
    {
        mainMenuCanvas.enabled = true;
        highScoreMenuCanvas.enabled = false;
    }
}