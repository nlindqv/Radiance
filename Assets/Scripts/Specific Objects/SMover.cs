using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// S mover.
/// </summary>

public class SMover : MonoBehaviour {

	Vector3 center;
	Vector3 start;
	Vector3 end;

	float step;

	BezierCurve curve;

	bool togglDir;
	bool isMoving;

	void Start () 
	{
		
		curve = GetComponentInChildren<BezierCurve> ();
		start = curve.GetPointAt (0);
		end = curve.GetPointAt (1);

		Debug.DrawLine (start, end, Color.cyan, 10f);
	}


	void OnTriggerEnter(Collider Other)
	{
		if (!isMoving) {
			Vector3 hitPoint = Other.gameObject.transform.position;

			//get closest point from hitPoint to BezierCurve (approximates amongst n points)
			float n = 20;
	//		Might be used to better determine closest point..
	//		n = curve.resolution * curve.pointCount;

			Vector3 hit2Line = curve.GetPointAt(0) - hitPoint;

			float minDist = Vector3.Distance (hitPoint, curve.GetPointAt (0));
			print (minDist);

			for (float t = 1/n; t < 1f; t += (1/n)) {
				float distComp = Vector3.Distance (hitPoint, curve.GetPointAt (t));
				if (distComp < minDist) {
					hit2Line = curve.GetPointAt(t) - hitPoint;
					minDist = distComp;
					step = t;
				}
			}
			Vector3 transport = hitPoint + hit2Line;

			print (curve.GetPointAt (step) + " on curve to object " + hitPoint);
			print (hit2Line + " w/ dist " + minDist);

			Vector3 prevTransform = Other.gameObject.transform.position;
			Other.gameObject.transform.position = Vector3.MoveTowards (prevTransform, transport, 1);

			if (Vector3.Distance (transport, start) > Vector3.Distance (transport, end)) {
				togglDir = false;
			} else {
				togglDir = true;
			}
			//		Debug.DrawLine (Vector3.zero, transport, Color.blue, 10f);
			//		Debug.DrawLine (Vector3.zero, hitPoint, Color.red, 10f);
		}
	}

	void OnTriggerStay(Collider Other)
	{
		isMoving = true;
		Vector3 prevTransform = Other.gameObject.transform.position;
//
//		if (prevTransform.Equals (end) || prevTransform.Equals(start)) {
//			togglDir = !togglDir;
//		}
		if (togglDir) {
			Other.gameObject.transform.position = Vector3.MoveTowards (prevTransform, curve.GetPointAt (step), 1f);
			step += 0.01f;
			if (step >= 1) {
				step = 1;
				togglDir = !togglDir;
			}
		} else {
			Other.gameObject.transform.position = Vector3.MoveTowards (prevTransform, curve.GetPointAt (step), 1f);
			step -= 0.01f;
			if (step <= 0.01) {
				step = 0;
				togglDir = !togglDir;
			}
		}

	}
	void OnTriggerExit(Collider Other){
		isMoving = false;
	}
}
