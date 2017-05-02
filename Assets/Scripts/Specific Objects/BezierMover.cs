using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Moves the object back & forth along a BezierCurve
/// Drag BezierCurve into script to determine which curve
/// </summary>

public class BezierMover : MonoBehaviour {

	/// <summary>
	/// toggles direction, false=clockwise if curve is closed
	/// </summary>
	public bool toggl;

	//private boolean to determine if curve is closed
	bool closedCurve;

	//move determines how far along the curve we are 0<move<1
	float move;

	//the curve to move along
	public BezierCurve b;

	/// <summary>
	/// Speed to move along curve, typical values 1<speed<20
	/// </summary>
	public float speed;
	private float step;


	void Start () {
		//default values of speed & curve if not set
		if(b == null)
			b = GetComponent<BezierCurve> ();

		if (speed == 0)
			speed = 10f;
		step = speed / 2000;

		closedCurve = b.close;

		//default value of move
		if (toggl) {
			move = 0.99f;
		} else {
			move = 0.0f;
		}
			
	}

	void FixedUpdate () {
		//if curve is closed we just start over curve from 0.99 -> 0
		if (closedCurve) {
			if (!toggl) {
				move += step;
				transform.position = Vector3.MoveTowards (transform.position, b.GetPointAt (move), speed);
				if (move > 0.99f)
					move = 0.0f;
			} else {
				move -= step;
				transform.position = Vector3.MoveTowards (transform.position, b.GetPointAt (move), speed);
				if (move <= 0.0f)
					move = 0.99f;
			}

		//Otherwise we go from start to end of curve (0.0++) and then from end to start (0.99--)
		} else {
			
			if (toggl)
				move += step;
			else
				move -= step;

			transform.position = Vector3.MoveTowards (transform.position, b.GetPointAt (move), speed);

			//if we are at end/start of curve reset move value & toggle direction
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
