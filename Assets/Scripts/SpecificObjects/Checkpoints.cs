
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoints : IInteractables, ICollectable
{	public int bounceValue;
	public float speed = 1f;
	bool taken;
	Behaviour halo;

    private Material mat;
    private static Color darkPink = new Color32(155, 13, 107, 255);
    private static Color lightPink = new Color32(224, 53, 166, 255);

    void Start()
	{		
		halo = (Behaviour)GetComponent("Halo");
        mat = GetComponentInChildren<Renderer>().material;
        Debug.Log(mat);
        Off();
	}
	bool ICollectable.Collected()
	{
		return taken;
	}
	void Update()
	{
		transform.Rotate (new Vector3(15,30,45) * Time.deltaTime * speed); 		
	}

    public override void HandleUpdate()
    {
        taken = false;
        Off();
    }

    public override void HandleLaserCollision(LaserRay laserHit)
	{
		Vector3 norm = Vector3.Normalize(laserHit.dir);
		Vector3 margin = Vector3.Scale(norm, new Vector3(0.01f, 0.01f, 0.01f));
		Vector3 startPoint = laserHit.HitPoint + margin;
		LaserRay newRay = GetLaser(laserHit.BounceValue);
		if (newRay == null) return;
		Transform parentTranform = laserHit.transform.parent;
		newRay.transform.parent = parentTranform;
		newRay.transform.position = startPoint;
		newRay.transform.rotation = (Quaternion.LookRotation(laserHit.dir));
        newRay.SetColor(laserHit.BounceValue, laserHit.Color);
		newRay.GenerateLaserRay();
        taken = true;
        On();
	}

	void On()
	{
		halo.enabled = true;
        speed = 10.0f;
        // change color to light pink
        mat.color = lightPink;
        //color

	}
	void Off()
	{
		halo.enabled = false;
        // chnage color to dark pink
        speed = 1.0f;
        mat.color = darkPink;
	}

}
