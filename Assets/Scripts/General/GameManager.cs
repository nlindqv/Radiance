﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public enum GameMode { laserMode, mirrorMode, none };
	public enum GameState {tutorial,gameRunning,endScreen};

    public static GameMode gameMode = GameMode.none;
    private static GameState prevGameState;
	public GameObject laserRay;
	public ViewController UI;
	public TargetMaster targetMaster;

	public static GameState gameState;
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

		gameState = GameState.tutorial;
        prevGameState = GameState.tutorial;
        gameMode = GameMode.none;
       
		UI = GameObject.Find ("UI").GetComponent<ViewController> ();
		targetMaster = GameObject.Find ("TargetMaster").GetComponent<TargetMaster> ();
		UI.transform.Find ("MellanMeny").gameObject.SetActive (false);

		if (tutorialIndex >= 0) {
			LoadTutorial (tutorialIndex);
		}
	}


	void FixedUpdate ()
	{
        if(prevGameState == GameState.tutorial && gameState == GameState.gameRunning)
        {
            gameMode = GameMode.laserMode;
            UI.ShowGameModeButton();
        }
		switch (gameState) {
            case GameState.tutorial:
                
            break;
            case GameState.gameRunning:
            UI.ShowGameModeButton();
			CheckLevelCompleted ();
			break;
		case GameState.endScreen:
			CheckNextState ();
			break;
		default:
			break;
		}
        prevGameState = gameState;
	}

	private void LoadTutorial (int index)
	{
		// Load info about tutorial
		string title = "title";
		string text = "sample text";
		Image icon = null;
		UI.NewTutorial (title, text, icon);
	}

	private void CheckLevelCompleted ()
	{
		if (targetMaster.CheckLevelCompleted ()) {
			LoadLevelEndScreen ();
			gameState = GameState.endScreen;
            gameMode = GameMode.none;
		}
	}

	private void LoadLevelEndScreen ()
	{
		// Load info about which level got completed
		string level = "Level";
		UI.ShowEndScreen (level, targetMaster.GetCollectables ());
	}

	private void CheckNextState ()
	{
		switch (UI.select) {
		case ViewController.Select.menu:
			MainMenu ();
			break;
		case ViewController.Select.replay:
			Replay ();
			break;
		case ViewController.Select.next:
			NextScene ();
			break;
		default:
			break;
		}
	}

	private void NewScene (int n)
	{ // where n is offset from current scene
		Scene activeScene = SceneManager.GetActiveScene ();
		SceneManager.LoadScene (activeScene.buildIndex + n);
		Debug.Log ("Entering next scene");
	}
    	

	private void NextScene ()
	{
		NewScene (1);
		gameState = GameState.gameRunning;
	}

	private void Replay ()
	{
		NewScene (0);
		gameState = GameState.gameRunning;
	}

	private void MainMenu ()
	{
		//NewScene (menuIndex);
	}

}