using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveOnpath : MonoBehaviour
{

	public PathControl pathFollow;

	public int CurrentId = 0;
	public float v;
	private float reachDis = 1.0f; 
	public float rotSpeed = 5.0f;
	int end;

	public string pathName;
	Vector3 last_pos;
	Vector3 curr;
	// Use this for initialization
	void Start ()
	{
		//pathFollow = GameObject.Find (pathName).GetComponent<pathControl> ();
		end = pathFollow.paths.Count;
		last_pos = transform.position;
	}
	
	// Update is called once per frame
	void Update () 
	{
		float distance = Vector3.Distance (pathFollow.paths [CurrentId].position, transform.position);
		transform.position = Vector3.MoveTowards (transform.position, pathFollow.paths [CurrentId].position, Time.deltaTime * v);
//		var rotation = Quaternion.LookRotation (pathFollow.paths [CurrentId].position - transform.position);
//		transform.rotation = Quaternion.Slerp (transform.rotation, Time.deltaTime * v);
		if (distance <= reachDis) 
		{
			CurrentId++;
		} 
		//Debug.Log ();
		if( CurrentId >= end)
		{
			//pathFollow.paths.Reverse ();
			CurrentId = 0;
			transform.position = Vector3.MoveTowards (transform.position, pathFollow.paths [CurrentId].position, Time.deltaTime * v);
		}

	}

}
