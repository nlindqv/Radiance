using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ViewController : MonoBehaviour {
	public static bool gameMode = true;
	Text text;


	void Start () {
		// Access button label and set default mode to lasermode
		text = GetComponentInChildren<Button> ().gameObject.GetComponentInChildren<Text>();
		text.text = "Laser Mode";
	}
	

	void Update () {
		
	}
	public void Click (){
		// On button click, toggle between Mirror and Laser mode
		if (gameMode) text.text = "Mirror Mode";
		else text.text = "Laser Mode";

		gameMode = !gameMode; // Toggle global variable

	}
}
