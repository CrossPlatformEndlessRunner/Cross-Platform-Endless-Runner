using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class OptionsMenuManager : MonoBehaviour {

    public Canvas mainMenuCanvas;
    public Canvas optionsMenuCanvas;

	// Use this for initialization
	void Start () 
    {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
	
	}

    public void BackToMainMenu()
    {
        mainMenuCanvas.enabled = true;
        optionsMenuCanvas.enabled = false;
    }
}
