using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ViewController : MonoBehaviour {
	public static bool gameMode = true;
	Text text;
	public enum Select {menu, replay, next, none};
	public Select select = Select.none;
    private Transform tutorial;
	private Transform endScreen;


	void Start () {
		// Access button label and set default mode to lasermode
		//text = GetComponentInChildren<Button> ().gameObject.GetComponentInChildren<Text>();
        text = transform.Find("toggleGameMode").gameObject.GetComponentInChildren<Text>();
        text.text = "Laser Mode";
        tutorial = transform.Find("Tut_UI");

		endScreen = transform.Find ("MellanMeny");
        Debug.Log(tutorial);
        //NewTutorial("Bajs", "Lite text", null);

	}
	

	void Update () {
		
	}
	public void Click (){
		// On button click, toggle between Mirror and Laser mode
		if (gameMode) text.text = "Mirror Mode";
		else text.text = "Laser Mode";

		gameMode = !gameMode; // Toggle global variable
	}

    public void OkClick()
    {
        tutorial.gameObject.SetActive(false);
    }

    public void NewTutorial(string title, string text, Image image)
    {
		if (tutorial == null) {
			tutorial = transform.Find("Tut_UI");
		}

		tutorial.gameObject.SetActive(true);       
        tutorial.Find("Tilte").GetComponent<RectTransform>().GetComponent<Text>().text = title;
        tutorial.Find("Text").GetComponent<RectTransform>().GetComponent<Text>().text = text;        
    }
	public void Replay () {
		select = Select.replay;
	}
	public void Next () {
		select = Select.next;
	}
	public void Menu () {
		select = Select.menu;
	}
	public Select getSelect(){
		return select;
	}
	public void ShowEndScreen(string levelName, int starCount){
		endScreen.gameObject.SetActive (true);
		endScreen.Find ("Level").GetComponent<RectTransform> ().GetComponent<Text> ().text = levelName;
		// Visa rätt antal stjärnor beroende på starCount
	}
}
