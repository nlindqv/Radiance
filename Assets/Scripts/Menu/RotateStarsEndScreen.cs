using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateStarsEndScreen : MonoBehaviour {

	bool active1;
	bool active2;
	bool active3;
	bool rotate = false;

	RectTransform Star1;
	RectTransform Star2;
	RectTransform Star3;


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

		rotate = true;
	}

	// Update is called once per frame
	void Update () {
		if (rotate) {
			//if stars are filled rotate stars
			if(active1)
				Star1.Rotate (transform.forward * 0.1f);
			if (active2)
				Star2.Rotate (transform.forward * 0.1f);
			if(active3)
				Star3.Rotate (transform.forward * 0.1f);
		}

	}

}
