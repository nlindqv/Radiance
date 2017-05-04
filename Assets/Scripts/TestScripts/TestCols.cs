using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Should print collider & name upon collision with trigger & non-trigger
/// If child has collider & parent should trigger, try adding rigidbody 
/// where Gravity=false, isKinematic=true – Only works one parent up
/// </summary>
public class TestCols : MonoBehaviour {

	void Start () {
		string message = name + " initiated Collision Testscript";
		Debug.Log (message);
	}

	public void OnTriggerEnter(Collider other){
		string message = name + " was triggered by " + other;
		Debug.Log (message);
	}

	public void OnCollisionEnter(Collision other){
		string message = name + " had a collision with " + other;
		Debug.Log (message);
	}
}
