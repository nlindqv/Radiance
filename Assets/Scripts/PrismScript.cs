using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Transform))]
public class PrismScript : MonoBehaviour, IInteractables
{
	//	private GameObject prev;
	private GameObject pr;
	private GameObject pr1;
	private GameObject pr2;
	//private transform gram;
	public GameObject ray;
	public GameObject Lig;
	private Vector3 tren = new Vector3(0,0,1);
	private Vector3 tren1 = new Vector3(1,0,1);
	private Vector3 tren2 = new Vector3(-1,0,1);

	private Vector3 tr = new Vector3(0,0,-1);
	private Vector3 tr1 = new Vector3(1,0,-1);
	private Vector3 tr2 = new Vector3(-1,0,-1);
	float r;
	float t;

	public int bounceValue;

	void start()
	{
		//transform = GetComponent<transform> ();
		r = Mathf.Floor(Lig.transform.position.z);
		t = Mathf.Floor(transform.position.z);
	}

	void Update () 
	{
		Destroy(pr);
		Destroy (pr1);
		Destroy (pr2);
	}

	public void HandleLaserCollision(LaserRay laserHit)
	{        
		if (laserHit.HitNormal.z > 0) {
			pr = Instantiate (ray, transform.position, Quaternion.LookRotation (tr)); 
			pr1 = Instantiate (ray, transform.position, Quaternion.LookRotation (tr1));
			pr2 = Instantiate (ray, transform.position, Quaternion.LookRotation (tr2));
		} else {
//			pr = Instantiate (ray, transform.position, Quaternion.LookRotation (tren)); 
//			pr1 = Instantiate (ray, transform.position, Quaternion.LookRotation (tren1));
//			pr2 = Instantiate (ray, transform.position, Quaternion.LookRotation (tren2));
		}
	}
}