using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveOnSquare : MonoBehaviour {

		public PathControl pathFollow;

		public int CurrentId = 1;
		public float v;
	    public float s = -0.06f;
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
		    transform.position = pathFollow.paths [CurrentId].position;
		    transform.position = Vector3.MoveTowards (transform.position, pathFollow.paths [CurrentId].position, Time.deltaTime * v);
			//pathFollow.paths.RemoveAt (0);
		}

		// Update is called once per frame
		void Update () 
		{
			float distance = Vector3.Distance (pathFollow.paths [CurrentId].position, transform.position);
	      	float x = pathFollow.paths [CurrentId].position.x;
	     	float y = pathFollow.paths [CurrentId].position.y;
	     	float z = pathFollow.paths [CurrentId].position.z;
		    Vector3 vi = new Vector3 (x-s,y,z-s);
			transform.position = Vector3.MoveTowards (transform.position, vi, Time.deltaTime * v);
			if (distance <= reachDis) 
			{
				CurrentId++;
			} 
			//Debug.Log ();
			if( CurrentId >= end)
			{
				//pathFollow.paths.Reverse ();
				CurrentId = 1;
			}

		}



}
