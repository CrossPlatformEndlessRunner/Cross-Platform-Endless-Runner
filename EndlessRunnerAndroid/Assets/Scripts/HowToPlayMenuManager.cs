using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HowToPlayMenuManager : MonoBehaviour {

    public Canvas mainMenuCanvas;
    public Canvas howToPlayMenuCanvas;

	// Use this for initialization
	void Start () 
    {
        howToPlayMenuCanvas.enabled = false;
	}
	
	// Update is called once per frame
	void Update () 
    {
	
	}

    public void BackToMainMenu()
    {
        mainMenuCanvas.enabled = true;
        howToPlayMenuCanvas.enabled = false;
    }
}
