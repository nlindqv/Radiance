using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basic : MonoBehaviour {

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
//
//	void OnCollisionEnter(Collider other){
//		Debug.Log (other);
//		print ("Collision");
//	}
}
