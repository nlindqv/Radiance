using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Moves the object back & forth along a BezierCurve
/// Drag BezierCurve into script
/// </summary>

public class BezierTest : MonoBehaviour {

	bool toggl;
	bool closedCurve;

	float move;
	public BezierCurve b;
	public float speed;



	void Start () {
		if(b == null)
			b = GetComponent<BezierCurve> ();
		if (speed == 0)
			speed = 1f;

		closedCurve = b.close;
		Debug.Log (closedCurve);

		move = 0.0f;
	}

	void FixedUpdate () {
		if (closedCurve) {

			move += 0.005f;
			transform.position = Vector3.MoveTowards (transform.position, b.GetPointAt (move), speed);
			if (move > 0.99f)
				move = 0.0f;
			
		} else {
			
			if (toggl)
				move += 0.005f;
			else
				move -= 0.005f;

			transform.position = Vector3.MoveTowards (transform.position, b.GetPointAt (move), speed);
			if (move > 0.99f) {
				toggl = !toggl;
				move = 0.99f;
			} else if (move <= 0.0f) {
				toggl = !toggl;
				move = 0.0f;
			}
		}
	}
}
