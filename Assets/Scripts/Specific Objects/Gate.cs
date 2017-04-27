using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour, IInteractables {
	public GameObject ray;
	public bool hit;
	public Color gateColor;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {

	}

	public void HandleLaserCollision(LaserRay laserHit){
		if (laserHit.Color.Equals(gateColor)) {
			Vector3 direction = laserHit.transform.forward;
			Vector3 startPoint = new Vector3 (laserHit.HitPoint.x+0.01f, laserHit.HitPoint.y, laserHit.HitPoint.z + 0.01f);
			GameObject newRay = Instantiate (ray, startPoint, Quaternion.LookRotation (laserHit.transform.forward));
			Transform parentTranform = laserHit.transform.parent;
			newRay.transform.parent = parentTranform;
			LaserRay newLaser = newRay.GetComponent<LaserRay> ();
			newLaser.Color = gateColor;
			}
	}
}
