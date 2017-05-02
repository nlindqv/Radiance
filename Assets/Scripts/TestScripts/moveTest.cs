using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Test script for moving objects w/ keys
/// A=left arrow, S=down arrow, D=right arrow, W=up arrow
/// checks if object has rigidbody and uses it for transform, otherwise uses transform
/// </summary>
[RequireComponent(typeof(float))]
public class moveTest : MonoBehaviour {

	//private variables for position & game objects
	private Vector3 lastPos;
	private Vector3 reverse;

	private Rigidbody rb;
	private Camera cam;

	/// <summary>
	/// Set speed for moving faster, default value is 0.1
	/// </summary>
	public float speed;

	/// <summary>
	/// Set to true to print current position, sets to false after printing
	/// </summary>
	public bool printPos;

	// private boolean to determine if we use rigidbody or transform
	private bool useRB;


	void Start () {
		
		lastPos = transform.position;
		rb = GetComponent<Rigidbody> ();

		if (rb != null) {
			useRB = true;
		}

		cam = Camera.main;

		if (speed = 0.0f) {
			speed = 0.1f;
		}

		//vector to multiply w/ directions to get reverse
		reverse = new Vector3 (-1, -1, -1);
	}
	
	//Move-script runs in update, not very efficient but only used for testing
	void Update () {
		//if object has rigidbody, else use transform
		if (useRB) {
			if (Input.GetKey (KeyCode.W) || Input.GetKey (KeyCode.UpArrow))
				rb.position = Vector3.MoveTowards (lastPos, cam.transform.up + lastPos, speed);
			if (Input.GetKey (KeyCode.S) || Input.GetKey (KeyCode.DownArrow))
				rb.position = Vector3.MoveTowards (lastPos, Vector3.Scale (cam.transform.up, reverse) + lastPos, speed);
			if (Input.GetKey (KeyCode.D) || Input.GetKey (KeyCode.RightArrow))
				rb.position = Vector3.MoveTowards (lastPos, cam.transform.right + lastPos, speed);
			if (Input.GetKey (KeyCode.A) || Input.GetKey (KeyCode.LeftArrow))
				rb.position = Vector3.MoveTowards (lastPos, Vector3.Scale (cam.transform.right, reverse) + lastPos, speed);
		} else {
			if (Input.GetKey (KeyCode.W) || Input.GetKey (KeyCode.UpArrow))
				transform.position = Vector3.MoveTowards (lastPos, cam.transform.up + lastPos, speed);
			if (Input.GetKey (KeyCode.S) || Input.GetKey (KeyCode.DownArrow))
				transform.position = Vector3.MoveTowards (lastPos, Vector3.Scale (cam.transform.up, reverse) + lastPos, speed);
			if (Input.GetKey (KeyCode.D) || Input.GetKey (KeyCode.RightArrow))
				transform.position = Vector3.MoveTowards (lastPos, cam.transform.right + lastPos, speed);
			if (Input.GetKey (KeyCode.A) || Input.GetKey (KeyCode.LeftArrow))
				transform.position = Vector3.MoveTowards (lastPos, Vector3.Scale (cam.transform.right, reverse) + lastPos, speed);
		}
		//update lastposition to current position
		lastPos = transform.position;

		//if Print Position=true, print current position & set to false
		if (printPos) {
			print (lastPos);
			printPos = false;
		}

	}
}
