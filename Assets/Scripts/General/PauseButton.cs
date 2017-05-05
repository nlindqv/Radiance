using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseButton : MonoBehaviour {

	ViewController UI;

    public void PauseGame() {
        GameManager.gameState = GameManager.GameState.gamePaused;
        Time.timeScale = 0.0F;
        Button pauseButton = GetComponentInChildren<Button>();
        pauseButton.gameObject.SetActive(false);
        //här skall kod köras för att visa pause-menyn
		//GetComponentInParent<.showPauseMenu();

		UI = GetComponentInParent<ViewController> ();
		UI.ShowPauseScreen (2);

		//showPauseMenu();


    }

	private void showPauseMenu (int starCount){
		Transform pausemenu = transform.parent.Find ("PauseMenu");
		pausemenu.gameObject.SetActive (true);
		pausemenu.Find("Level").GetComponent<RectTransform>().GetComponent<Text>().text = "Tjolahopp";
		for (int i=0; i <= starCount; i++) {
		}
	}

}
