using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Transform))]

public class LightSplitter : IInteractables
{
    //Color of gate and laserRay-conversion
    public Color One;
    public Color Two;
    public Color Three;

    private Transform laserOne; 
    private Transform laserTwo; 
    private Transform laserThree;

    // hit varible to check if object has been hit alredy or not
    private bool hit;



    void Start()
    {
        hit = false;
        laserOne = this.transform.Find("Spawn1");
        laserTwo = this.transform.Find("Spawn2");
        laserThree = this.transform.Find("Spawn3");
    }

    public override void HandleUpdate()
    {
        hit = false;
    }

    public override void HandleLaserCollision(LaserRay ray)
    {
        if (Math.Abs(ray.HitNormal.x -this.transform.right.x) <= 0.001f && !hit)
        {
            hit = true;
            Color[] colorArray = { One, Two, Three };
            Transform[] positionArray = { laserOne, laserTwo, laserThree };
            for (int i = 0; i < positionArray.Length; i++)
            {
                Transform parentTransform = ray.transform.parent;
                LaserRay newRay = GetLaser(ray.BounceValue);
                newRay.transform.position = positionArray[i].position;
                newRay.transform.rotation = Quaternion.LookRotation(positionArray[i].up);
                newRay.transform.parent = parentTransform;
                newRay.SetColor(ray.BounceValue, colorArray[i]);
                newRay.GenerateLaserRay();
            }
        }
    }  
}