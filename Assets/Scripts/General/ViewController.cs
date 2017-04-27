using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ViewController : MonoBehaviour {
	public static bool gameMode = true;
	Text text;

    private Transform tutoraial;


	void Start () {
		// Access button label and set default mode to lasermode
		//text = GetComponentInChildren<Button> ().gameObject.GetComponentInChildren<Text>();
        text = transform.Find("toggleGameMode").gameObject.GetComponentInChildren<Text>();
        text.text = "Laser Mode";
        tutoraial = transform.Find("Tut_UI");
        Debug.Log(tutoraial);
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
        tutoraial.gameObject.SetActive(false);
    }

    public void NewTutorial(string title, string text, Image image)
    {
        tutoraial.gameObject.SetActive(true);       
        tutoraial.Find("Tilte").GetComponent<RectTransform>().GetComponent<Text>().text = title;
        tutoraial.Find("Text").GetComponent<RectTransform>().GetComponent<Text>().text = text;        
    }


}
