using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FadePanel : MonoBehaviour

{
    public Image myPanel;
    float fadeTime = 3f;


    void Start()
    {
        myPanel.CrossFadeAlpha(80, fadeTime, true);
    }

}