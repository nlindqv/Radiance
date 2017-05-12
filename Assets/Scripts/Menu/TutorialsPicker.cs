using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TutorialsPicker : MonoBehaviour {
	public Button tutorialButton;
	private Transform tutorialButtonCanvas;
	private TutorialList tutorials;
	private Transform tutorialWindow;
	// Use this for initialization
	void Start () {	
		tutorialButtonCanvas = transform.Find ("TutorialButtons");
		tutorials = MemoryManager.LoadAllTutorials ();
		tutorialWindow = transform.Find ("Tut_UI");
		GenerateButtons ();
		tutorialWindow.GetComponentInChildren<Button>().onClick.AddListener (delegate(){HideTutorial ();});
	}

	private void GenerateButtons(){
		for (int i = 0; i < tutorials.list.Count; i++) {
			GameObject newButton = Instantiate(tutorialButton.gameObject, new Vector3(0.0f, 0.0f, 0.0f), Quaternion.LookRotation(tutorialButton.transform.forward));
			newButton.GetComponent<RectTransform> ().localScale = new Vector3 ((float)GetComponentInParent<RectTransform>().lossyScale.x, (float)GetComponentInParent<RectTransform>().lossyScale.y, (float)GetComponentInParent<RectTransform>().lossyScale.z);

			int index = i;
			newButton.transform.SetParent(tutorialButtonCanvas.transform);
			newButton.GetComponent<Button>().onClick.AddListener(delegate(){showTutorial(index);});
			// Set button text to tutorial-title
			Text buttonText = newButton.GetComponentInChildren<Text>();
			buttonText.text = tutorials.list[i].title;
			newButton.SetActive (true);
		}
	}
	private void showTutorial(int i){
		Debug.Log (i);
		tutorialWindow.Find("Title").GetComponent<RectTransform>().GetComponent<Text>().text = tutorials.list[i].title;
		tutorialWindow.Find("Text").GetComponent<RectTransform>().GetComponent<Text>().text = tutorials.list[i].tutorialText;
		tutorialWindow.gameObject.SetActive (true);
	}
	private void HideTutorial(){
		tutorialWindow.gameObject.SetActive (false);
	}
}
