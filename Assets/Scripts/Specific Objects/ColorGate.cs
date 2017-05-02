using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class script for ColorGate
/// Set color to determine what color to change laser to
/// if color is changed during gameplay, make sure to set dirty=true to update gateRenderer 
/// </summary>
public class ColorGate : MonoBehaviour, IInteractables {

	//Color of gate and laserRay-conversion
    public Color color;

	//Use dirty to render new color of gate during gameplay
	public bool dirty;

	//
    private BoxCollider col;
    private Transform child; 

	void Start () {

		//get all renderers
        col = GetComponent<BoxCollider>();
       
		UpdateColor ();
        
		//set size of collider based on scale of object
		Vector3 scale = this.transform.Find("GateModel").gameObject.transform.localScale;
        col.size =  new Vector3(0.0f, scale.y, scale.z);


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
	/// <param name="ray">Ray.</param>
	public void HandleLaserCollision(LaserRay ray){
		//Get direction of LaserRay
		Vector3 direction = ray.HitPoint - ray.transform.position;

		//Moves the new laserray a small amount so that the new ray does not hit the gate (which would trigger new collision)
		Vector3 norm = Vector3.Normalize(direction);
		Vector3 margin = Vector3.Scale(norm, new Vector3(0.01f, 0.01f, 0.01f));

		Transform parentTransform = ray.transform.parent;

		//create new ray, set parent to parent from previous ray (lightSource)
		LaserRay newRay = Instantiate (ray, ray.HitPoint+margin, Quaternion.LookRotation(direction));
		newRay.transform.parent = parentTransform;
		newRay.SetColor (ray.BounceValue-1, color);

	}
}
