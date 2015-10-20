using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Timer : MonoBehaviour
{
    public string       defaultTimerText = "Timer: ";
    private Text        timerText = null;
    private float       timePassed = 0.0f;

    // Use this for initialization
    void Start()
    {
        timerText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        //if game has started
        timePassed += Time.deltaTime;
        timerText.text = defaultTimerText + timePassed.ToString("F2");

    }
}