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
    private Behaviour halo;


    void Start()
	{
        //Default is no hit from laser
        halo = (Behaviour)GetComponent("Halo");
        hit = false;
	}



	/*void Update() {
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
    */

	public override void HandleUpdate()
    {
        // updated when no hit is register -> turn halo of
        halo.enabled = false;
        hit = false;
    }

	//Handles Collision with laser
	public override void HandleLaserCollision (LaserRay ray)
	{
		//Turn on halo and indicate hit to targetmaster
        halo.enabled = true;
		hit = true;
		lastHitRay = ray;
	}  
}