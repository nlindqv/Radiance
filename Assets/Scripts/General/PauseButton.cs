using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseButton : MonoBehaviour {

	ViewController UI;

    public void PauseGame() {
        GameManager.gameState = GameManager.GameState.gamePaused;
		PauseTime ();
        Button pauseButton = GetComponentInChildren<Button>();
        pauseButton.gameObject.SetActive(false);
        //här skall kod köras för att visa pause-menyn
		//GetComponentInParent<.showPauseMenu();


		UI = GetComponentInParent<ViewController> ();
		UI.ShowPauseScreen (MemoryManager.LoadScore());

		//showPauseMenu();
		UI.transform.Find("PauseMenu").GetComponent<RotateStarsPaused>().InitStars();
//		RotateStarsPaused.InitStars();

    }


	private void PauseTime(){
		Time.timeScale = 0.0F;
	}
	private void ResumeTime(){
		Time.timeScale = 1.0F;
	}

	public void resume(){
		UI.HidePauseScreen ();
		GameManager.gameState = GameManager.GameState.gameRunning;
		ResumeTime ();
		//Button pauseButton = GetComponentInChildren<Button>();
		//pauseButton.gameObject.SetActive(true);
	}

	public void restart(){
		UI.HidePauseScreen ();
		ResumeTime ();
		UI.Replay ();

	}

	public void menu(){
		UI.HidePauseScreen ();
		ResumeTime ();
		UI.Menu ();
	}

}
