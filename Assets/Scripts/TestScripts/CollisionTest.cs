using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Should print collider & "Collision" upon collision with trigger
/// decomment OnCollisionEnter() to get same behavior for non-trigger
/// </summary>
public class CollisionTest : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Debug.Log (name);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other){
		Debug.Log (other);
		print ("Collision");
	}

	void OnCollisionEnter(Collider other){
		Debug.Log (other);
		print ("Collision");
	}
}
