using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MainMenuManager : MonoBehaviour
{

    public Canvas mainMenuCanvas;
    public Canvas optionsMenuCanvas;
    public Canvas highScoreCanvas;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void OpenOptionsMenu()
    {
        mainMenuCanvas.enabled = false;
        optionsMenuCanvas.enabled = true;
    }

    public void OpenHighScoreMenu()
    {
        mainMenuCanvas.enabled = false;
        highScoreCanvas.enabled = true;
    }

    public void PlayGame()
    {
        Application.LoadLevel((int)Utilities.LEVEL_NUMS.GAME);
    }
}