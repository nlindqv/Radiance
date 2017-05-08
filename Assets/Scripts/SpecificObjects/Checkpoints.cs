
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoints : IInteractables, ICollectable
{
	public GameObject r;
	public int bounceValue;
	public float speed = 1f;
	bool taken;
	Vector3 hit;
	Vector3 pr;
	Vector3 pr1;
	Vector3 perp;
	Behaviour halo;
	Renderer renderer;
	float s;
	Vector3 proj;
	Vector3 dire;
	float magn;
	float dist;
	void Start()
	{
		renderer = GetComponent<Renderer> ();
		halo = (Behaviour)GetComponent("Halo");
		s = Vector3.Distance (r.transform.position,transform.position);
		pr = transform.position - r.transform.position;
		pr1 = r.transform.position - transform.position;

	}
	bool ICollectable.Collected()
	{
		return taken;
	}
	void Update()
	{
		transform.Rotate (new Vector3(15,30,45) * Time.deltaTime * speed); 
		pr = transform.position - r.transform.position;
		s = Vector3.Distance (r.transform.position,transform.position);
		Debug.DrawLine (r.transform.position,transform.position,Color.green);
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
		newRay.Color = laserHit.Color;
		newRay.GenerateLaserRay();

		dire = laserHit.dir;
		proj = Vector3.Project (pr,laserHit.dir);
		perp = pr - proj;
		float distance = perp.magnitude;
		magn = proj.magnitude;
		dist = Mathf.Sqrt (Mathf.Pow(magn,2) + Mathf.Pow(s,2));
		float angle = Vector3.Angle (pr, dire);

		if (angle > 0 && angle < 1.2)
		{
			On ();
		} 
		else
		{
			Off ();
		}
		taken = true;
	}

	void On()
	{
		halo.enabled = true;
	}
	void Off()
	{
		halo.enabled = false;
	}

}
