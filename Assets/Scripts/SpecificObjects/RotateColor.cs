using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateColor : MonoBehaviour {

    private Color color;
    private float counter;

    public float speed;

    // Use this for initialization
    void Start () {        
        counter = 0.0f;
        if (speed == 0.0f) speed = 0.5f; 
	}
	
	// Update is called once per frame
	void Update () {
        counter += Time.deltaTime;
        GetComponent<ColorChanger>().color = Color.HSVToRGB(Mathf.Abs(Mathf.Sin(counter*speed)), 1.0f, 1.0f);
        //Debug.Log(GetComponent<ColorChanger>().color);       
        GetComponent<ColorChanger>().UpdateColor();
    }
}
