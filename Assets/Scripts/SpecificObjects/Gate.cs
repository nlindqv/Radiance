using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : IInteractables {
	public GameObject ray;
	public bool hit;
	public Color gateColor;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        //hit = false;
	}

    public override void HandleLaserCollision(LaserRay laserHit)
    {
        hit = true;
        if (colorEqual(laserHit.Color, gateColor))
        {
           
            Vector3 direction = laserHit.transform.forward;
            Vector3 norm = Vector3.Normalize(direction);
            Vector3 margin = Vector3.Scale(norm, new Vector3(0.01f, 0.01f, 0.01f));
            Vector3 startPoint = laserHit.HitPoint + margin;//new Vector3(laserHit.HitPoint.x + 0.01f, laserHit.HitPoint.y, laserHit.HitPoint.z + 0.01f);
            LaserRay newRay;  //Instantiate(ray, startPoint, Quaternion.LookRotation(laserHit.transform.forward));

           if (laserStack.size() == 0)
            {
                newRay = Instantiate(ray, startPoint, Quaternion.LookRotation(direction)).GetComponent<LaserRay>();
            }
            else
            {
                newRay = laserStack.pop();
                newRay.transform.position = startPoint;
                newRay.transform.rotation = Quaternion.LookRotation(laserHit.transform.forward);
            }            
            Transform parentTranform = laserHit.transform.parent;
            newRay.transform.parent = parentTranform;            
            newRay.Color = gateColor;
            newRay.GenerateLaserRay();
        }       
    }

    public bool colorEqual(Color one,  Color two)
    {
        return one.r == two.r && one.g == two.g && one.b == two.b;
    }
}
