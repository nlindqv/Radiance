using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SMover : MonoBehaviour {

	Vector3 center;
	Vector3 start;
	Vector3 end;

	float step;

	BezierCurve curve;
	public Collider col;

	bool togglDir;

	void Start () 
	{
		
		curve = GetComponentInChildren<BezierCurve> ();
		start = curve.GetPointAt (0);
		end = curve.GetPointAt (1);
		Debug.Log (start);
		Debug.Log (end);
		Debug.DrawLine (start, end, Color.cyan, 10f);
	}


	void OnTriggerEnter(Collider Other)
	{
		Debug.Log ("Collision");
		Vector3 hitPoint = Other.gameObject.transform.position;

		//get closest point from hitPoint to BezierCurve (approximates amongst n points)
		float n = 20;
		Vector3 hit2Line = hitPoint - curve.GetPointAt(0);
		float minDist = Vector3.Distance (hitPoint, curve.GetPointAt (0));

//		Might be used to better determine closest point..
//		n = curve.resolution * curve.pointCount;

		for (float t = 0.5f; t < 1f; t += (1f/n)) {
			float distComp = Vector3.Distance (hitPoint, curve.GetPointAt (t));
			if (distComp < minDist) {
				hit2Line = hitPoint - curve.GetPointAt(t);
				minDist = distComp;
				step = t;
			}
		}
		Vector3 transport = hitPoint + hit2Line;

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

	void OnTriggerStay(Collider Other)
	{

		Vector3 prevTransform = Other.gameObject.transform.position;

		if (prevTransform.Equals (end) || prevTransform.Equals(start)) {
			togglDir = !togglDir;
		}
		if (togglDir) {
			step += 0.01f;
			Other.gameObject.transform.position = Vector3.MoveTowards (prevTransform, curve.GetPointAt (step), 0.1f);
		} else {
			step -= 0.01f;
			Other.gameObject.transform.position = Vector3.MoveTowards (prevTransform, curve.GetPointAt (step), 0.1f);
		}

	}
}
