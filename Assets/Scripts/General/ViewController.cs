using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ViewController : MonoBehaviour
{
    private GameObject pauseButton;				    // toggle pause
    private GameObject toogleButton;				// toggle gamemode
    public enum Select { menu, replay, next, none };// states that could be entered in endscreen
    public Select select = Select.none;				// set selectstate to none
    private Transform tutorial;						// tutorial window
    private Transform endScreen;					// endscreen window
	private Transform pauseScreen;
    private Image fadePanel;						// endscreen fade panel

    void Start()
    {
        // Access button label and set default mode to lasermode
        toogleButton = transform.Find("toggleGameMode").gameObject;
        toogleButton.GetComponentInChildren<Text>().text = "Laser Mode";

        pauseButton = transform.Find(GameManager.PAUSE_BTN_NAME).gameObject;
        
		// Access to tutorial-window, endscreen-menu and fade-panel
        tutorial = transform.Find("Tut_UI");
        endScreen = transform.Find("MellanMeny");
		pauseScreen = transform.Find ("PauseMenu");
        fadePanel = transform.Find("FadePanel").GetComponent<Image>();

        initScene();
    }

    public void initScene()
    {
		// Hide  Tutorial, EndScreen, Fadepanel and gamemodebutton
        //HideTutorial();
        HideEndScreen();
		HidePauseScreen ();
        HideFadePanel();
        HideGameModeButton();
        HidePauseButton();
    }
    public void ToggleBtnClick()
    {
		// If gameMode is none, do nothing
        if (GameManager.gameMode == GameManager.GameMode.none) return;
        // On button click, toggle between Mirror and Laser mode
        if (GameManager.gameMode == GameManager.GameMode.laserMode){
            toogleButton.GetComponentInChildren<Text>().text = "Mirror Mode";
            GameManager.gameMode = GameManager.GameMode.mirrorMode;
        }
        else{
            toogleButton.GetComponentInChildren<Text>().text = "Laser Mode";
            GameManager.gameMode = GameManager.GameMode.laserMode;
        }
    }

    public void ShowGameModeButton()
    {
		// Show GameMode-button and set label text
        toogleButton.SetActive(true);
        if (GameManager.gameMode == GameManager.GameMode.mirrorMode)
        {
            toogleButton.GetComponentInChildren<Text>().text = "Mirror Mode";        
        }
        else
        {
            toogleButton.GetComponentInChildren<Text>().text = "Laser Mode";           
        }
    }
    public void HidePauseButton() {
        pauseButton.SetActive(false);
    }
    public void HideGameModeButton()
    {
        toogleButton.SetActive(false);
    }

    public void TutorialOkClick()
    {
		// Hide tutorial window and set gamestate to gamerunning
        HideTutorial();
        GameManager.gameState = GameManager.GameState.gameRunning;
    }



    public void NewTutorial(string title, string text, Image image)
    {
        if (tutorial == null)
            tutorial = transform.Find("Tut_UI");

		// Show tutorialwindow, set title and explanation text (and object icon)
        tutorial.gameObject.SetActive(true);
        tutorial.Find("Title").GetComponent<RectTransform>().GetComponent<Text>().text = title;
        tutorial.Find("Text").GetComponent<RectTransform>().GetComponent<Text>().text = text;
    }

    public void HideTutorial()
    {
		// Close tutorial window
        tutorial.gameObject.SetActive(false);
    }
    public void Replay()
    {
		// Set select to replay and close endScren
        select = Select.replay;
        endScreen.gameObject.SetActive(false);
    }
    public void Next()
    {
		// Set select to next and close endScreen
        select = Select.next;
        endScreen.gameObject.SetActive(false);
    }
    public void Menu()
    {
		// Set select to menu and close endScreen
        select = Select.menu;
        endScreen.gameObject.SetActive(false);
    }

    public void ShowEndScreen(string levelName, int starCount)
    {
		// Show endscreen, set level text, and fill right amount of stars
        endScreen.gameObject.SetActive(true);
        endScreen.Find("Level").GetComponent<RectTransform>().GetComponent<Text>().text = levelName;
        endScreen.Find("Star1").transform.GetChild(0).gameObject.SetActive(true);
        if (starCount > 1)
            LightStar(2);
        if (starCount > 2)
            LightStar(3);
        ShowFadePanel();
    }


    private void HideEndScreen()
    {
		// Close endscreen and hide fadepanel
        endScreen.gameObject.SetActive(false);
        HideFadePanel();
    }

	public void ShowPauseScreen(int starCount){
		pauseScreen = transform.Find ("PauseMenu");
		pauseScreen.gameObject.SetActive (true);
		pauseScreen.Find("Level").GetComponent<RectTransform>().GetComponent<Text>().text = "Tjolahopp";

		Debug.Log ("Showing pausescreen w/ " + starCount + " stars");
		for (int i=1; i <= starCount; i++) {
			Debug.Log (i);
			LightStar (i);
		}
	}

	//TODO: update pauseScreen to exist in ViewControl
	public void HidePauseScreen(){
		pauseScreen = transform.Find ("PauseMenu");
		//deactivate all stars
		pauseScreen.Find("Star1").gameObject.SetActive(false);
		pauseScreen.Find("Star2").gameObject.SetActive(false);
		pauseScreen.Find("Star3").gameObject.SetActive(false);
		pauseScreen.gameObject.SetActive (false);

	}

    private void LightStar(int i)
    {
		// Change color on star according to a index i
        endScreen.Find("Star" + i).transform.GetChild(0).gameObject.SetActive(true);
		pauseScreen.Find("Star" + i).gameObject.SetActive(true);
    }

    private void ShowFadePanel()
    {
        fadePanel.gameObject.SetActive(true);
        // fadePanel.CrossFadeAlpha(80, 3f, true);
    }
    private void HideFadePanel()
    {
        fadePanel.gameObject.SetActive(false);
    }
}
