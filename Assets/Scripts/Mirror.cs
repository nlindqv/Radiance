using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Klass för att hantera reflektion map. spegeln
/// </summary>
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
        //reflektera map. laserns riktningsvektor samt ytans normal
        Vector3 direction = Vector3.Reflect(laserHit.transform.forward,laserHit.HitNormal);
        LaserRay newLaser = Instantiate(laserSource, laserHit.HitPoint, Quaternion.LookRotation(direction)).GetComponent<LaserRay>(); 
        //sätt färg och minska bouncevalue
        newLaser.BounceValue = laserHit.BounceValue- 1;
        newLaser.Color = laserHit.Color;
    }
}
