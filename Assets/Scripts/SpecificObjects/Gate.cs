using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : IInteractables {
	public bool hit;
	public Color gateColor;

	// Use this for initialization
	void Start () {
        //sätt färg vid skapande av gaten
        Renderer renderer = GetComponent<Renderer>();
        renderer.material.SetColor("_TintColor", new Color(gateColor.r, gateColor.g, gateColor.b,128));
	}
	

    public override void HandleLaserCollision(LaserRay laserHit)
    {
        hit = true;
        if (colorEqual(laserHit.Color, gateColor))
        {           
            Vector3 direction = laserHit.transform.forward;
            Vector3 norm = Vector3.Normalize(direction);
            Vector3 margin = Vector3.Scale(norm, new Vector3(0.01f, 0.01f, 0.01f));
            Vector3 startPoint = laserHit.HitPoint + margin;
            LaserRay newRay = GetLaser(laserHit.BounceValue);
            if (newRay == null) return;
            Transform parentTranform = laserHit.transform.parent;
            newRay.transform.parent = parentTranform;
            newRay.transform.position = startPoint;
            newRay.transform.rotation = (Quaternion.LookRotation(direction));
            newRay.SetColor(laserHit.BounceValue, gateColor);
            newRay.GenerateLaserRay();
        }       
    }

    public bool colorEqual(Color one,  Color two)
    {
        return Math.Abs(one.r - two.r + one.g - two.g + one.b - two.b) <= 0.001f;
    }
}
