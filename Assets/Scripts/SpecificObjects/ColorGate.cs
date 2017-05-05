using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorGate : IInteractables {

/// <summary>
/// Class script for ColorGate
/// Set color to determine what color to change laser to
/// if color is changed during gameplay, make sure to set dirty=true to update gateRenderer 
/// </summary>



	//Color of gate and laserRay-conversion
    public Color color;

	//Use dirty to render new color of gate during gameplay
	public bool dirty;

	//Gate has collider and model as child.
    private BoxCollider col;
    private Transform child;


	void Start () {

		//get collider
        col = GetComponent<BoxCollider>();

		UpdateColor ();
        
		//set size of collider based on scale of object
		//Vector3 scale = this.transform.Find("GateModel").gameObject.transform.localScale;
        //col.size =  new Vector3(0.0f, scale.y, scale.z);

	}


	//if color has changed during gameplay, update renderer
	void Update(){
		if(dirty){
			UpdateColor ();
			dirty = false;
		}
	}

	/// <summary>
	/// Updates color of gate.
	/// </summary>
	void UpdateColor(){
		foreach (Renderer rend in this.GetComponentsInChildren<Renderer>())
		{
			rend.enabled = true;
			//modify alpha of color to set transperancy of gate
			color = new Color (color.r, color.g, color.b, 0.6f);
			rend.material.color = color;
		}
	}

	/// <summary>
	/// Creates a new ray with new color w/ slight offset from original ray.
	/// </summary>
	/// <param name="ray">LaserRay sent</param>
	public override void HandleLaserCollision(LaserRay ray){
		//Get direction of LaserRay

		Vector3 direction = ray.HitPoint - ray.transform.position;

		//Moves the new laserray a small amount so that the new ray does not hit the gate (which would trigger new collision)
		Vector3 norm = Vector3.Normalize(direction);
		Vector3 margin = Vector3.Scale(norm, new Vector3(0.01f, 0.01f, 0.01f));

		Transform parentTransform = ray.transform.parent;

        LaserRay newRay = GetLaser(ray.BounceValue); // = Instantiate (ray, ray.HitPoint+margin, Quaternion.LookRotation(direction));
        if (newRay == null) return; 
        newRay.transform.position = ray.HitPoint + margin;
        newRay.transform.rotation = Quaternion.LookRotation(ray.transform.forward);

        newRay.transform.parent = parentTransform;
		newRay.SetColor (ray.BounceValue, color);
        newRay.GenerateLaserRay();
	}
}
