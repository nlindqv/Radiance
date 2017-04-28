using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Moves the object back & forth along a BezierCurve
/// Drag BezierCurve into script
/// </summary>

[RequireComponent(typeof(BezierCurve))]
public class BezierMove : MonoBehaviour {

	bool toggl;

	float move;
	public BezierCurve b;
	public float speed;

	void Start () {
		if(b == null)
			b = GetComponent<BezierCurve> ();
		if (speed == 0)
			speed = 1f;

		move = 0.0f;
	}
	
	// Update is called once per frame
	void Update () {
		if (toggl)
			move += 0.005f;
		else
			move -= 0.005f;

		transform.position = Vector3.MoveTowards (transform.position, b.GetPointAt (move), speed);
		if (move > 0.99f) {
			toggl = !toggl;
			move = 0.99f;
		} else if(move <= 0.0f){
			toggl = !toggl;
			move = 0.0f;
		}

	}
}
