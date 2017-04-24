using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ViewController : MonoBehaviour {
	public static bool gameMode = true;
	Text text;
	// Use this for initialization
	void Start () {
		text = GetComponentInChildren<Button> ().gameObject.GetComponentInChildren<Text>();
		text.text = "Laser Mode";
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void Click (){
		if (gameMode) text.text = "Mirror Mode";
		else text.text = "Laser Mode";
		gameMode = !gameMode;
		Debug.Log ("Gamemode: " + gameMode);
	}
}
