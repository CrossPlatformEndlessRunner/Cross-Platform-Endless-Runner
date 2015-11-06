using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PauseMenuManager : MonoBehaviour
{
    public Canvas pauseMenuCanvas;
    private bool isPaused = false;

    // Use this for initialization
    void Start()
    {
        pauseMenuCanvas.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PauseButton()
    {
        if (!isPaused)
        {
            Pause();
        }
        else
        {
            Unpause();
        }
    }

    public void RestartButton()
    {
        pauseMenuCanvas.enabled = false;
        Time.timeScale = 1.0f;
        Application.LoadLevel(Application.loadedLevel);
    }

    public void ResumeButton()
    {
        Unpause();
    }

    public void BackToMenuButton()
    {
        Time.timeScale = 1.0f;
        Application.LoadLevel((int)Utilities.LEVEL_NUMS.MAIN_MENU);
    }

    private void Pause()
    {
        pauseMenuCanvas.enabled = true;
        Time.timeScale = 0.0f;
        isPaused = true;
    }

    private void Unpause()
    {
        pauseMenuCanvas.enabled = false;
        Time.timeScale = 1.0f;
        isPaused = false;
    }

    public bool IsPaused
    {
        get { return isPaused; }
    }
}