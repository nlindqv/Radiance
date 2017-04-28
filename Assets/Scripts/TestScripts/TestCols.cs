using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Should print collider & "Collision" upon collision with trigger & non-trigger
/// If child has collider & parent should trigger, try adding rigidbody 
/// where Gravity=false, isKinematic=true
/// </summary>
public class TestCols : MonoBehaviour {

	// Use this for initialization
	void Start () {
		string message = name + " initiated Collision Testscript";
		Debug.Log (message);
	}
	
	// Update is called once per frame
	void Update () {
		
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
