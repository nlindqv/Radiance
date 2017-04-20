using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Use with Targets, A master object with Targets as children
public class TargetMaster : MonoBehaviour {

	private Target[] Targets;
	private bool[] hits;

	void Start () {

		//Get all Target-scripts
		Targets = GetComponentsInChildren<Target> ();
		hits = new bool[Targets.Length];

	}
	

	// Update is called late in every frame to make sure all target hits are registered correctly
	void LateUpdate () {

		//Get all current hits for targets on level
		for(int i = 0; i < Targets.Length; i++){
			Target targScript = Targets [i];
			hits [i] = targScript.hit;
			//Debug.Log ("Target " + i + " hit: " + hits[i]);

		}
		//Check if all are hit (Optimize later)
		bool nextLevel = false;
		foreach(bool h in hits){
			if (!h) {
				nextLevel = false;
				break;
			} else {
				nextLevel = true;
			}
			//Debug.Log ("Should go to next level: " + nextLevel);
		}

		//if all are hit go to next scene
		if (nextLevel) {
			//next scene code here...
			Debug.Log ("Entering next scene");
		}

	}
}
