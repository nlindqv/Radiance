using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public const string PAUSE_BTN_NAME = "PauseButton";
    public enum GameMode { laserMode, mirrorMode, none };	// gameModes
	public enum GameState {tutorial,gameRunning,endScreen, gamePaused};	// gameStates available
	private int score = 0;

    public static GameMode gameMode = GameMode.none;		// init gameMode to none
    private static GameState prevGameState;					// save prev gameState
	public GameObject laserRay;
    [HideInInspector]
    public ViewController UI;                               // UI containing all panels etc.
    [HideInInspector]
    public TargetMaster targetMaster;
    [HideInInspector]
    public LaserMode laserMode;
	public static GameState gameState;

	private int tutorialIndex;
//	private string levelName;

    private LaserStack laserStack;
    private int numOfLasers = 100;

    private float MIN_FPS = 20;

    private bool prevMouseDown = true;


    float deltaTime = 0.0f;
    private float speed = 2.0f;
    private float lastClickTime = 0;
    private float catchTime = 0.3f;
    // Use this for initialization
    void Start ()
	{
		Input.multiTouchEnabled = false;
        //Prata med minnet
//		levelName = MemoryManager.LoadLevelName();
		tutorialIndex = MemoryManager.LoadTutorialIndex();

        laserMode = GameObject.Find("LightSource").GetComponent<LaserMode>();

        laserStack = new LaserStack();
        Debug.Log(GameObject.FindObjectsOfType(typeof(IInteractables)));
  
        foreach (IInteractables inter in GameObject.FindObjectsOfType(typeof(IInteractables)))
        {
            inter.SetLasers(laserStack);
            inter.SetLaser(laserRay.GetComponent<LaserRay>());
        }

        generateLaserStack();
        laserMode.laserStack = laserStack;       

        // Access UIs components and children
        UI = GameObject.Find ("UI").GetComponent<ViewController> ();

		// Access targetMaster
		targetMaster = GameObject.Find ("TargetMaster").GetComponent<TargetMaster> ();
		// Hide mellanmeny
		UI.transform.Find("Canvas").transform.Find("MellanMeny").gameObject.SetActive (false);

//        Debug.Log("tutorialIndex: " + tutorialIndex);
//        Debug.Log("playedBefore: " + MemoryManager.TutorialPlayedBefore(tutorialIndex));

		// If tutorial index = -1 dont show anything, otherwise load tutorial with index tutorialIndex
		if (tutorialIndex >= 0) {
			if (MemoryManager.TutorialPlayedBefore (tutorialIndex) == false) {
				// Start game with tutorial window #1
				// Start game with tutorial window #1
				gameState = GameState.tutorial;
				prevGameState = GameState.tutorial;
				gameMode = GameMode.none;

				LoadTutorial (tutorialIndex);
				Debug.Log ("tutorialPlayedBefore: " + MemoryManager.TutorialPlayedBefore (tutorialIndex));
				//Debug.Log(SceneManager.GetActiveScene().buildIndex);
				MemoryManager.SetTutorialPlayedBefore (tutorialIndex);
			} else {
				// Start game without tutorial
				gameState = GameState.gameRunning;
				prevGameState = GameState.gameRunning;
				gameMode = GameMode.laserMode;
			}
        } else {
			// Start game without tutorial
			gameState = GameState.gameRunning;
			prevGameState = GameState.gameRunning;
			gameMode = GameMode.laserMode;
		}
	}

    private void generateLaserStack()
    {
        for (int i = 0; i < numOfLasers; i++)
        {
            LaserRay newLaser = Instantiate(laserRay, new Vector3(0, 0, 0), Quaternion.identity).GetComponent<LaserRay>();
            laserStack.push(newLaser);
        }
    }

    void FixedUpdate ()
	{
		// When entering gameRunning from tutorial, show gameModebutton
        if(prevGameState == GameState.tutorial && gameState == GameState.gameRunning)
        {
            gameMode = GameMode.laserMode;
            UI.ShowGameModeButton();
        }
        // Decide which code is running according to gameState
        switch (gameState)
        {
            // Case tutorial, do something...
            case GameState.tutorial:
                break;
            // Case gameRunning, show gamemode-button and check if level is completed
            case GameState.gameRunning:
                //visa pause-knappen
                UI.transform.Find(PAUSE_BTN_NAME).gameObject.SetActive(true);
                UI.ShowGameModeButton();
                CheckLevelCompleted();
                DoubleClick();
                break;
            // Case endScreen, check what next state is
            case GameState.endScreen:
                if (Input.GetMouseButtonDown(0))
                {
                    StopCoroutine(Order());
                    LoadLevelEndScreen();
                }
                CheckNextState();
                //prevMouseDown = Input.GetMouseButtonDown(0);
                break;
            case GameState.gamePaused:
                CheckNextState();
                break;

            default:
                break;
        }
        prevGameState = gameState;
        RenderSettings.skybox.SetFloat("_Rotation", speed * Time.deltaTime + RenderSettings.skybox.GetFloat("_Rotation"));
        RenderSettings.skybox.SetFloat("_Exposure", Mathf.Sin(2 * Time.deltaTime + RenderSettings.skybox.GetFloat("_Rotation"))/8.0f + 1.0f);
        //Debug.Log(skybox.GetFloat("_Exposure"));
        //RenderSettings.skybox = skybox;
    }

    private void DoubleClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (Time.time - lastClickTime < catchTime)
            {
                if (gameMode == GameMode.laserMode) gameMode = GameMode.mirrorMode;
                else gameMode = GameMode.laserMode;
                //print("double click " + gameMode);

            }
         
            lastClickTime = Time.time;
        }
    }

    private void LoadTutorial (int index)
	{
		// Load info about tutorial
		Tutorial tut;
		if (index >= 0) {
			tut = MemoryManager.LoadTutorial (index);
		} else
			tut = new Tutorial();

		//load image from iconpath
		Sprite icon = MemoryManager.loadIcon (tut.iconPath);

		UI.NewTutorial (tut.title, tut.tutorialText, icon);
	}

	private void CheckLevelCompleted ()
	{
		// If all targets are hit, load endScreen and set gameMode = none
		if (targetMaster.CheckLevelCompleted ()) {
			//LoadLevelEndScreen ();
			gameState = GameState.endScreen;
            gameMode = GameMode.none;
			score = targetMaster.GetCollectables();
            StartCoroutine(Order());
		}
	}

	private void LoadLevelEndScreen ()
	{
        string level = "Level " + MemoryManager.LoadLevelIndex();
        //ändrat!
        MemoryManager.WriteScore2Memory(score);
        //yield return new WaitForSeconds(3.0f);
        UI.ShowEndScreen(level, score);                
    }
  

    IEnumerator Order()
    {
        foreach (IInteractables item in GameObject.FindObjectsOfType<IInteractables>())
        {
            EndScript.FloatAway(item.transform);
        }
        foreach (Target item in GameObject.FindObjectsOfType<Target>())
        {
            EndScript.FloatAway(item.transform);
        }
        foreach (LaserMode item in GameObject.FindObjectsOfType<LaserMode>())
        {
            EndScript.FloatAway(item.transform);
        }
        foreach (GameObject item in GameObject.FindGameObjectsWithTag("FloatAway"))
        {
            Debug.Log(GameObject.FindGameObjectsWithTag("FloatAway"));
            EndScript.FloatAway(item.transform);
        }
        speed = 4.0f;
        yield return new WaitForSeconds(3.0f);
        LoadLevelEndScreen();
    }

    private void CheckNextState ()
	{
		// Check select to decide what next state is
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
		// Load next level
		NewScene (1);
		gameState = GameState.gameRunning;
	}

	private void Replay ()
	{
		// Load same level again
		NewScene (0);
		gameState = GameState.gameRunning;
	}

	private void MainMenu ()
	{
        SceneManager.LoadScene("StartScene");
	}
		
	private void LoadLevelName(){
		string jsonString = File.ReadAllText (Application.dataPath + "/Resources/Levels.json");
		Debug.Log (jsonString);
	}   

    void Update()
    {
        deltaTime += (Time.deltaTime - deltaTime) * 0.1f;
    }

    void OnGUI()
    {
        int w = Screen.width, h = Screen.height;

        GUIStyle style = new GUIStyle();

        Rect rect = new Rect(0, 0, w, h * 2 / 100);
        style.alignment = TextAnchor.UpperLeft;
        style.fontSize = h * 2 / 50;
        style.normal.textColor = new Color(0.0f, 0.0f, 0.5f, 1.0f);
        float msec = deltaTime * 1000.0f;
        float fps = 1.0f / deltaTime;
        //if(fps < MIN_FPS)disableGlow();

        // check in memory if we should disable glow
        if (MemoryManager.LoadGlow() != 1) disableGlow();
        string text = string.Format("{0:0.0} ms ({1:0.} fps)", msec, fps);
        GUI.Label(rect, text, style);
    }

    private void disableGlow()
    {
        Camera.main.GetComponent<MKGlowSystem.MKGlow>().enabled = false;
    }
}
