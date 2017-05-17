using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RotateStarsPaused : MonoBehaviour {

	bool active1;
	bool active2;
	bool active3;
	bool rotate = false;

	RectTransform Star1;
	RectTransform Star2;
	RectTransform Star3;

	Color col1;
	Color col2;
	Color col3;


	// Use this for initialization
	public void InitStars(){

		//check if stars are filled
		//		checkActive = true;
		active1 = transform.Find ("Star1").GetChild (0).gameObject.activeSelf;
		active2 = transform.Find ("Star2").GetChild (0).gameObject.activeSelf;
		active3 = transform.Find ("Star3").GetChild (0).gameObject.activeSelf;

		//get transform-information
		Star1 = transform.Find ("Star1").GetComponent<RectTransform>();
		Star2 = transform.Find ("Star2").GetComponent<RectTransform>();
		Star3 = transform.Find ("Star3").GetComponent<RectTransform>();

//		//Get colors
//		col1 = Star1.GetComponent<Image>().color;
//		col2 = Star2.transform.GetChild(0).GetComponent<Image>().color;
//		col3 = Star3.transform.GetChild(0).GetComponent<Image>().color;

		rotate = true;
	}

	// Update is called once per frame
	void Update () {
		if (rotate) {
			//if stars are filled rotate stars
			if (active1) {
				Star1.Rotate (transform.forward * 0.1f);

//				if(col1.r < 130) //If color is dark increase, if light decrease
				//col1 = new Color (col1.r - 0.001f, col1.g - 0.001f, col1.b - 0.001f, col1.a);
//				col1 = Color.black;
//				print (col1);
//				else
//					col1 = new Color (col1.r - 10, col1.g - 10, col1.b - 10, col1.a);
			}
			if (active2) {
				Star2.Rotate (transform.forward * 0.1f);
			}
			if (active3) {
				Star3.Rotate (transform.forward * 0.1f);
			}
		}

	}

}
