using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorGate : IInteractables {
	//Color of gate and laserRay-conversion
    public Color color;

	//Use dirty to render new color of gate during gameplay
	public bool dirty;

    private BoxCollider col;
    private Transform child;

	void Start () {
        col = GetComponent<BoxCollider>();
        foreach (Renderer rend in this.GetComponentsInChildren<Renderer>())
        {
			rend.enabled = true;
			//modify alpha of color
			color = new Color (color.r, color.g, color.b, 0.6f);
            rend.material.color = color;
        }
        
		Vector3 scale = this.transform.Find("GateModel").gameObject.transform.localScale;
        col.size =  new Vector3(0.0f, scale.y, scale.z);


	}

	void Update(){
		if(dirty){
			UpdateColor ();
		}
	}

	void UpdateColor(){
		foreach (Renderer rend in this.GetComponentsInChildren<Renderer>())
		{
			rend.enabled = true;
			//modify alpha of color
			color = new Color (color.r, color.g, color.b, 0.6f);
			rend.material.color = color;
		}
	}


	public override void HandleLaserCollision(LaserRay ray){
		//Direction of LaserRay
		Vector3 direction = ray.HitPoint - ray.transform.position;

		//Moves the new laserray a small amount so that the new ray does not hit the gate (which triggers new collision)
		Vector3 norm = Vector3.Normalize(direction);
		Vector3 margin = Vector3.Scale(norm, new Vector3(0.01f, 0.01f, 0.01f));

		Transform parentTransform = ray.transform.parent;

        LaserRay newRay; // = Instantiate (ray, ray.HitPoint+margin, Quaternion.LookRotation(direction));
        if (laserStack.size() == 0)
        {
            newRay = Instantiate(ray, ray.HitPoint + margin, Quaternion.LookRotation(direction)).GetComponent<LaserRay>();
        }
        else
        {
            newRay = laserStack.pop();
            newRay.transform.position = ray.HitPoint + margin;
            newRay.transform.rotation = Quaternion.LookRotation(ray.transform.forward);
        }

        newRay.transform.parent = parentTransform;
		newRay.SetColor (ray.BounceValue-1, color);
        newRay.GenerateLaserRay();
	}
}
