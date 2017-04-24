using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Transform))]
public class PrismScript : MonoBehaviour, IInteractables
{
	private GameObject pr;
	private GameObject pr1;
	private GameObject pr2;

	public GameObject ray;
	private Vector3 tr = new Vector3(0,0,-1);
	private Vector3 tr1 = new Vector3(1,0,-1);
	private Vector3 tr2 = new Vector3(-1,0,-1);

	public int bounceValue;

	public void HandleLaserCollision(LaserRay laserHit)
	{        
		Transform parentTransform = laserHit.transform.parent;

		if (laserHit.HitNormal.z > 0) {
			pr = Instantiate (ray, transform.position, Quaternion.LookRotation (tr)); 
			pr.transform.parent = parentTransform;
			pr1 = Instantiate (ray, transform.position, Quaternion.LookRotation (tr1));
			pr1.transform.parent = parentTransform;
			pr2 = Instantiate (ray, transform.position, Quaternion.LookRotation (tr2));
			pr2.transform.parent = parentTransform;
		} 
	}
}