using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
	private enum GameState {gameRunning,endScreen};

	public GameObject laserRay;
	public ViewController UI;
	public TargetMaster targetMaster;

	private GameState gameState;
	private string levelName;
	private int tutorialIndex = 1;

	// Use this for initialization
	void Start ()
	{
		/*
			"Prata med minne"


		levelName = loadName();
		loadScore();
		loadTutorialIndex();
		*/
		gameState = GameState.gameRunning;
		UI = GameObject.Find ("UI").GetComponent<ViewController> ();
		targetMaster = GameObject.Find ("TargetMaster").GetComponent<TargetMaster> ();
		UI.transform.Find ("MellanMeny").gameObject.SetActive (false);
		Debug.Log (targetMaster.getCollectables ());
		if (tutorialIndex >= 0) {
			loadTutorial (tutorialIndex);

		}
	}


	void FixedUpdate ()
	{
		switch (gameState) {
		case GameState.gameRunning:
			checkLevelCompleted ();
			break;
		case GameState.endScreen:
			checkNextState ();
			break;
		default:
			break;
		}
	}

	private void loadTutorial (int index)
	{
		// Load info about tutorial
		string Title = "title";
		string Text = "TEXT";
		Image Icon = null;
		UI.NewTutorial (Title, Text, Icon);
	}

	private void checkLevelCompleted ()
	{
		if (targetMaster.checkLevelCompleted ()) {
			loadLevelEndScreen ();
			gameState = GameState.endScreen;
		}
	}

	private void loadLevelEndScreen ()
	{
		// Load info about which level got completed
		string Level = "Level";
		UI.ShowEndScreen (Level, targetMaster.getCollectables ());
	}

	private void checkNextState ()
	{
		switch (UI.getSelect ()) {
		case ViewController.Select.menu:
			mainMenu ();
			break;
		case ViewController.Select.replay:
			replay ();
			break;
		case ViewController.Select.next:
			nextScene ();
			break;
		default:
			break;
		}
	}

	private void newScene (int n)
	{ // where n is offset from current scene
		Scene activeScene = SceneManager.GetActiveScene ();
		SceneManager.LoadScene (activeScene.buildIndex + n);
		Debug.Log ("Entering next scene");
	}



		

	private void nextScene ()
	{
		newScene (1);
	}

	private void replay ()
	{
		newScene (0);
	}

	private void mainMenu ()
	{
		//newScene (menuIndex);
	}

}
