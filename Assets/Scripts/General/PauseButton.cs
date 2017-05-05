using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseButton : MonoBehaviour {


    public void PauseGame() {
        GameManager.gameState = GameManager.GameState.gamePaused;
        Time.timeScale = 0.0F;
        Button pauseButton = GetComponentInChildren<Button>();
        pauseButton.gameObject.SetActive(false);
        //här skall kod köras för att visa pause-menyn
    }

}
