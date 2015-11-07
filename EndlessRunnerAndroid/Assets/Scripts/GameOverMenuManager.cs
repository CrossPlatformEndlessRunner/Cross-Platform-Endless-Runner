using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameOverMenuManager : MonoBehaviour
{
    public Canvas gameOverCanvas;

    // Use this for initialization
    void Start()
    {
        if (gameOverCanvas != null)
        {
            gameOverCanvas.enabled = false;
        }

        
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