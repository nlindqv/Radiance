using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Use with Target Master, A master object with Targets as children
public class TargetMaster : MonoBehaviour {

	private TargetCollision[] Targets;
	private bool[] hits;

	// Use this for initialization
	void Start () {

		Targets = GetComponentsInChildren<TargetCollision> ();
		hits = new bool[Targets.Length];
		Debug.Log ("Get all children");
		//Debug.Log ();

	}
	
	// Update is called once per frame
	// SHOULD NOT BE UPDATED EVERY FRAME??
	void Update () {
		
		Debug.Log ("Getting all " + Targets.Length + " hits.");
		//Get all current hits for targets on level
		for(int i = 0; i < Targets.Length; i++){
			TargetCollision targScript = Targets [i];
			hits [i] = targScript.hit;

		}
		Debug.Log ("Checking bools");
		//Check if all are hit (Optimize later)
		bool nextLevel = false;
		foreach(bool h in hits){
			if (!h) {
				nextLevel = false;
				break;
			} else {
				nextLevel = true;
			}
		}

		//if all are hit go to next scene
		if (nextLevel) {
			//next scene code here...
			Debug.Log("Entering next scene");
		}

	}
}
