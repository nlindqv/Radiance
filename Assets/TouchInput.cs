using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchInput: MonoBehaviour {
	Touch myTouch;
	Movable movable;

	public void Start(){
		movable = GetComponent<Movable> ();

	}

	void Update () {
		myTouch = Input.GetTouch(0);
		TouchPhase phase = myTouch.phase;
		if (phase == TouchPhase.Began) {
			Debug.Log ("began");
			movable.FirstInputClick (myTouch);
		} else if (phase == TouchPhase.Moved) {
			Debug.Log ("moved");
			movable.FirstInputDrag (myTouch);
		} else if (phase == TouchPhase.Ended) {
			Debug.Log ("ended");
			movable.FirstInputUp (myTouch);
		}
	}
}

