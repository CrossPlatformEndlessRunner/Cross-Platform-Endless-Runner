using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Timer : MonoBehaviour
{
    public string       defaultTimerText = "Timer: ";
    private Text        timerText = null;
    private float       timePassed = 0.0f;
    private bool        isGameOver = false;

    // Use this for initialization
    void Start()
    {
        timerText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        //if game has started
        if (!isGameOver)
        {
            timePassed += Time.deltaTime;      
        }
        timerText.text = defaultTimerText + timePassed.ToString("F2");
    }

    void OnEnable()
    {
        GameLogicManager.playerIsDead += PlayerDeath;
    }

    void OnDisable()
    {
        GameLogicManager.playerIsDead -= PlayerDeath;
    }

    private void PlayerDeath()
    {
        isGameOver = true;
    }

    public float TimePassed
    {
        get { return timePassed; }
    }
}