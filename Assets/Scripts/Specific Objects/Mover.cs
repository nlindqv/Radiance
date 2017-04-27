using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour {

	Vector3 center;
	Vector3 start;
	Vector3 end;
	Vector3 direction;

	bool togglDir;

	void Start () 
	{
		center = transform.position;
		direction = transform.forward;

		float magn = transform.localScale.z/2;
		direction.Scale(new Vector3(magn, magn, magn));
		start = center + direction;
		end = center - direction;

		Debug.DrawLine (start, end, Color.green, 10f);
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}
	void OnTriggerEnter(Collider Other)
	{
		Vector3 hitPoint = Other.gameObject.transform.position;
		Vector3 hit2Line = center - hitPoint;
		Vector3 proj = Vector3.Project (hit2Line, direction);
		Vector3 transport = hitPoint + hit2Line - proj;

		Vector3 prevTransform = Other.gameObject.transform.position;
		Other.gameObject.transform.position = Vector3.MoveTowards (prevTransform, transport, 1f);

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
		if(togglDir)
			Other.gameObject.transform.position = Vector3.MoveTowards (prevTransform, end, 0.1f);
		else
			Other.gameObject.transform.position = Vector3.MoveTowards (prevTransform, start, 0.1f);


	}
}
