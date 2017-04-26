using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour, IInteractables {
	public GameObject ray;
	public bool hit;
	public Color gateColor;
	// public Color laserColor;    for debugging

	// Use this for initialization
	void Start () {
		hit = false;
	//	laserColor = ray.GetComponent<LaserRay> ().Color;
	//	gateColor = new Color(3,5,236,0);

	}
	
	// Update is called once per frame
	void Update () {

	}

	public void HandleLaserCollision(LaserRay laserHit){
		Debug.Log (laserHit.Color);
		Debug.Log (gateColor);
	//	if (laserHit.Color.Equals(gateColor)) {
			hit = true;
			Vector3 direction = laserHit.transform.forward;
			GameObject newRay = Instantiate (ray, laserHit.HitPoint, Quaternion.LookRotation (laserHit.transform.forward));
			Transform parentTranform = laserHit.transform.parent;
			newRay.transform.parent = parentTranform;
			LaserRay newLaser = newRay.GetComponent<LaserRay> ();
			newLaser.Color = gateColor;


		//}
	}
}
