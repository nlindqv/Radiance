using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Transform))]
public class Mirror : MonoBehaviour, IInteractables
{
    public GameObject laserSource;
    private Transform objTransform;
	// Use this for initialization
	void Start () {
        objTransform = GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void HandleLaserCollision(LaserRay laserHit)
    {
        float angle = Vector3.Angle(laserHit.HitNormal, laserHit.transform.forward); // laserHit.HitPoint
        Vector3 direction = laserHit.HitNormal;//laserHit.transform.eulerAngles;
        direction += Vector3.up + new Vector3(0, angle); //90 + 
        LaserRay newLaser = Instantiate(laserSource, laserHit.HitPoint, Quaternion.Euler(direction)).GetComponent<LaserRay>();
        newLaser.BounceValue = laserHit.BounceValue- 1;
    }
}
