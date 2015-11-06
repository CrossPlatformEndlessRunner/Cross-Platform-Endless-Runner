using UnityEngine;
using System.Collections;

public static class Utilities
{
    public enum LEVEL_NUMS
    {
        MAIN_MENU = 0,
        GAME = 1,
    };

    private static string playerPrefsHighScoreString = "highScore";

    public static string PlayerPrefsHighScoreString
    {
        get { return Utilities.playerPrefsHighScoreString; }
    }
}