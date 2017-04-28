using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ViewController : MonoBehaviour
{
    public static bool gameMode = true;

    private Text toogleButtonText;
    public enum Select { menu, replay, next, none };
    public Select select = Select.none;
    private Transform tutorial;
    private Transform endScreen;
    private Image fadePanel;

    void Start()
    {
        // Access button label and set default mode to lasermode
        toogleButtonText = transform.Find("toggleGameMode").gameObject.GetComponentInChildren<Text>();
        toogleButtonText.text = "Laser Mode";
        tutorial = transform.Find("Tut_UI");
        endScreen = transform.Find("MellanMeny");
        fadePanel = transform.Find("FadePanel").GetComponent<Image>();
    }

    public void initScene()
    {        
        //HideTutorial();
        HideEndScreen();
        HideFadePanel();
        HideGameModeButton();
    }

    public void Click()
    {
        // On button click, toggle between Mirror and Laser mode
        if (gameMode) toogleButtonText.text = "Mirror Mode";
        else toogleButtonText.text = "Laser Mode";

        gameMode = !gameMode; // Toggle global variable
    }

    public void ShowGameModeButton()
    {
        toogleButtonText.gameObject.SetActive(true);
    }

    public void HideGameModeButton()
    {
        toogleButtonText.gameObject.SetActive(false);
    }

    public void OkClick()
    {
        HideTutorial();
    }

    public void NewTutorial(string title, string text, Image image)
    {
        if (tutorial == null)
        {
            tutorial = transform.Find("Tut_UI");
        }

        tutorial.gameObject.SetActive(true);
        tutorial.Find("Title").GetComponent<RectTransform>().GetComponent<Text>().text = title;
        tutorial.Find("Text").GetComponent<RectTransform>().GetComponent<Text>().text = text;
    }

    public void HideTutorial()
    {
        tutorial.gameObject.SetActive(false);
    }
    public void Replay()
    {
        select = Select.replay;
        endScreen.gameObject.SetActive(false);
    }
    public void Next()
    {
        select = Select.next;
        endScreen.gameObject.SetActive(false);
    }
    public void Menu()
    {
        select = Select.menu;
        endScreen.gameObject.SetActive(false);
    }

    public void ShowEndScreen(string levelName, int starCount)
    {
        endScreen.gameObject.SetActive(true);
        endScreen.Find("Level").GetComponent<RectTransform>().GetComponent<Text>().text = levelName;
        endScreen.Find("Star1").transform.GetChild(0).gameObject.SetActive(true);
        if (starCount > 1)
            LightStar(2);
        if (starCount > 2)
            LightStar(3);
        ShowFadePanel();
    }

    private void HideEndScreen()
    {
        endScreen.gameObject.SetActive(false);
        HideFadePanel();
    }

    private void LightStar(int i)
    {
        endScreen.Find("Star" + i).transform.GetChild(0).gameObject.SetActive(true);
    }

    private void ShowFadePanel()
    {
        fadePanel.gameObject.SetActive(true);
        // fadePanel.CrossFadeAlpha(80, 3f, true);
    }
    private void HideFadePanel()
    {
        fadePanel.gameObject.SetActive(false);
    }
}
