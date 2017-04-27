using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BezierMove : MonoBehaviour {
	float move;
	BezierCurve b;
	// Use this for initialization
	void Start () {
		b = GetComponent<BezierCurve> ();
		move = 0.0f;
	}
	
	// Update is called once per frame
	void Update () {
		move += 0.001f;

		transform.position = Vector3.MoveTowards (transform.position, b.GetPointAt (move), 1f);
	}
}
