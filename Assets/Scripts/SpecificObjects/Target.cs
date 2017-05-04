using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Used with Targetmaster as parent
public class Target : IInteractables
{
	private Renderer rend;
	private LaserRay lastHitRay;
	public bool hit;
	//Colors to toggle between laser hit and not hit
	public Color defaultCol;
	public Color targetHit;

	void Start()
	{
		//Get the renderer and enable rendering
		rend = GetComponentInChildren<Renderer>();
		rend.enabled = true;

		//Default is no hit from laser
		hit = false;

		//Assign the default color
		Material mat = rend.material;
		mat.color = defaultCol;
	}


	void Update() {
		//If there is no hit make sure target is default color
		if (!hit) {
			Material mat = rend.material;
			mat.color = defaultCol;
		}
		if (lastHitRay == null)
			hit = false;
		//updates hit to false every frame, happens before laserCollision
		//hit = false;
	}

	//Handles Collision with laser
	public override void HandleLaserCollision (LaserRay ray)
	{
		//Change material and indicate hit to targetmaster
		Material mat = rend.material;
		mat.color = targetHit;
		hit = true;
		lastHitRay = ray;
	}  
}