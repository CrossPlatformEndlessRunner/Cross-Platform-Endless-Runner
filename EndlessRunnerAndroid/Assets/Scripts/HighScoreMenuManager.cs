using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HighScoreMenuManager : MonoBehaviour
{
    public Canvas mainMenuCanvas;
    public Canvas highScoreMenuCanvas;

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

    }

    public void BackToMainMenu()
    {
        mainMenuCanvas.enabled = true;
        highScoreMenuCanvas.enabled = false;
    }
}