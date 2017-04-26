using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorGate : MonoBehaviour, IInteractables {

	//Color of gate and laserRay-conversion
    public Color color;

    private BoxCollider col;
    private Transform child; 

	void Start () {
        col = GetComponent<BoxCollider>();
        foreach (Renderer rend in this.GetComponentsInChildren<Renderer>())
        {
			rend.enabled = true;
            rend.material.color = color;          
        }
        
		Vector3 scale = this.transform.Find("GateModel").gameObject.transform.localScale;
        col.size =  new Vector3(0.0f, scale.y, scale.z);    

	}

	public void HandleLaserCollision(LaserRay ray){
		//Direction of LaserRay
		Vector3 direction = ray.HitPoint - ray.transform.position;

		//Moves the new laserray a small amount so that the new ray does not hit the gate (which triggers new collision)
		Vector3 norm = Vector3.Normalize(direction);
		Vector3 margin = Vector3.Scale(norm, new Vector3(0.01f, 0.01f, 0.01f));

		ray.Color = color;
		Instantiate (ray, ray.HitPoint+margin, Quaternion.LookRotation(direction));
	}
}
