using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetCollision : MonoBehaviour, IInteractables
{
	private Renderer rend;
	public Color neutral;
	public Color targetHit;

	public bool hit;

	void Start()
	{
		//Get the renderer and enable rendering
		rend = GetComponentInChildren<Renderer>();
		rend.enabled = true;

		//Upon start 
		hit = false;

		//Assign the neutral color
		Material mat = rend.material;
		mat.color = neutral;
		//Debug.Log (this + " color assigned");
	}
		
	void Update() {
		if (!hit) {
			Material mat = rend.material;
			mat.color = neutral;
		}

		hit = false;
	}


	public void HandleLaserCollision (LaserRay ray)
	{
		//Debug.Log ("Laser Collision");
		Material mat = rend.material;
		mat.color = targetHit;
		hit = true;
	}

}