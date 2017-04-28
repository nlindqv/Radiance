using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(float))]
public class moveTest : MonoBehaviour {

	private Vector3 lastPos;
	private Vector3 reverse;

	private Rigidbody rb;
	private Camera cam;

	public float speed;
	public bool printPos;
	private bool useRB;

	// Use this for initialization
	void Start () {
		lastPos = transform.position;
		rb = GetComponent<Rigidbody> ();
		if (rb != null) {
			useRB = true;
		}
		speed = 0.1f;

		cam = Camera.main;

		reverse = new Vector3 (-1, -1, -1);
	}
	
	// Update is called once per frame
	void Update () {
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
		lastPos = transform.position;

		if (printPos) {
			print (lastPos);
			printPos = false;
		}

	}
}
