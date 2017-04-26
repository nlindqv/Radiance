using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChanger : MonoBehaviour {

	//color of gate
	public Color color;

	//geometry variables for gate
//	private Vector3 position;
//	private float height;
//	private float width;

	// Use this for initialization
	void Start () {
//		position = transform.position;
//		height = transform.lossyScale.x;
//		width = transform.lossyScale.z;

		//Assign gate color, render must be enabled
		GetComponent<Renderer>().enabled = true;
		GetComponent<Renderer>().material.color = color;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void HandleLaserCollision(LaserRay ray){
		if(ray.Color.Equals(this.color)){
			Vector3 direction = ray.HitPoint - ray.transform.position;
			LaserRay newRay = ray;
			newRay.Color = color;
			Instantiate (newRay, ray.HitPoint, Quaternion.LookRotation(direction));
		}
	}
}
