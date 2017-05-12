using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChanger : IInteractables {

/// <summary>
/// Class script for ColorGate
/// Set color to determine what color to change laser to
/// if color is changed during gameplay, make sure to set dirty=true to update gateRenderer 
/// </summary>



	//Color of gate and laserRay-conversion
    public Color color;


	//Gate has collider and model as child.
    private BoxCollider col;
    private Transform child;
    private ParticleSystem ps;
    private ParticleSystem p1;
    private ParticleSystem p2;
    private ParticleSystem p3;
	void Start () {
		//get collider
        col = GetComponent<BoxCollider>();
        ps = this.transform.FindChild("core_tint").gameObject.GetComponent<ParticleSystem>() ;
        p1 = this.transform.FindChild("glow_birth").transform.FindChild("p1").GetComponent<ParticleSystem>();
        p2 = this.transform.FindChild("glow_birth").transform.FindChild("p2").GetComponent<ParticleSystem>();
        p3 = this.transform.FindChild("glow_birth").transform.FindChild("p3").GetComponent<ParticleSystem>();
		UpdateColor ();
	}

	/// <summary>
	/// Updates color of gate.
	/// </summary>
	public void UpdateColor(){
        //update core-glow
        UnityEngine.ParticleSystem.MainModule main = ps.main;
        main.startColor = color;
        Gradient grad = new Gradient();
        grad.SetKeys(new GradientColorKey[] { new GradientColorKey(color, 1f) }, new GradientAlphaKey[] {new GradientAlphaKey(0.0f, 0.0f), 
            new GradientAlphaKey(1f, 0.25f),new GradientAlphaKey(1f, 0.75f), new GradientAlphaKey(0.0f, 1.0f) } );
        var col = ps.colorOverLifetime;
        col.color = grad;

        //update particle glow color
        main = p1.main;
        main.startColor = color;
        main = p2.main;
        main.startColor = color;
        main = p3.main;
        main.startColor = color;
	}

	/// <summary>
	/// Creates a new ray with new color w/ slight offset from original ray.
	/// </summary>
	/// <param name="ray">LaserRay sent</param>
	public override void HandleLaserCollision(LaserRay ray){
		//Get direction of LaserRay

		Vector3 direction = ray.HitPoint - ray.transform.position;

		//Moves the new laserray a small amount so that the new ray does not hit the gate (which would trigger new collision)
		Vector3 norm = Vector3.Normalize(direction);
		Vector3 margin = Vector3.Scale(norm, new Vector3(0.01f, 0.01f, 0.01f));

		Transform parentTransform = ray.transform.parent;

        LaserRay newRay = GetLaser(ray.BounceValue);
        if (newRay == null) return; 
        newRay.transform.position = ray.HitPoint + margin;
        newRay.transform.rotation = Quaternion.LookRotation(ray.transform.forward);

        newRay.transform.parent = parentTransform;
        newRay.SetColor(ray.BounceValue, color);
        newRay.GenerateLaserRay();
	}
}
