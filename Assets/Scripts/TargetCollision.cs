using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetCollision : MonoBehaviour
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

	}

	//Target is hit
	void OnCollisionEnter (Collision col)
	{
		if (col.gameObject.name == "ray") {
			Material mat = rend.material;
			mat.color = targetHit;
			hit = true;
		}
	}

	void Update() {
		if (!hit) {
			Material mat = rend.material;
			mat.color = neutral;
		}
		hit = false;
	}

	/*
	 * void HandleLaserCollision (Gameobject ray)
	{
		Material mat = rend.material;
		mat.color = targetHit;
		hit = true;
	}

	void Update()
	{
		hit = false;
		
	}
	 * /

	//Target is no longer hit
	void OnCollisionExit (Collision col)
	{
		if (col.gameObject.name == "ray") {
			Material mat = rend.material;
			mat.color = neutral;
			hit = false;
		}
	}


}
*/
}