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
            pauseMenuCanvas.enabled = true;
            Time.timeScale = 0.0f;
            isPaused = true;
        }
        else
        {
            pauseMenuCanvas.enabled = false;
            Time.timeScale = 1.0f;
            isPaused = false;
        }
    }

    public void RestartButton()
    {

    }

    public void ResumeButton()
    {

    }

    public bool IsPaused
    {
        get { return isPaused; }
    }
}