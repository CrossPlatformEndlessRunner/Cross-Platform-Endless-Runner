using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameLogicManager : MonoBehaviour
{
    private float scoreToAddEverySecond = 5.0f;
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
        }
    }
}