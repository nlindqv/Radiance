using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Klass för att hantera reflektion map. spegeln
/// </summary>
[RequireComponent(typeof(Transform))]
public class Reflective : IInteractables
{
    public GameObject ray;
    public int bounceValue;

    public override void HandleLaserCollision(LaserRay laserHit)
    {
        //reflektera map. laserns riktningsvektor samt ytans normal
        Vector3 direction = Vector3.Reflect(laserHit.transform.forward, laserHit.HitNormal);
        Transform parentTransform = laserHit.transform.parent;
        LaserRay newRayGameObj;
        if (laserStack.size() == 0)
        {
           newRayGameObj = Instantiate(ray, laserHit.HitPoint, Quaternion.LookRotation(direction)).GetComponent<LaserRay>();
        }
        else
        {
            newRayGameObj = laserStack.pop();
            newRayGameObj.transform.position = laserHit.HitPoint;
            newRayGameObj.transform.rotation = Quaternion.LookRotation(direction);           
        }

        newRayGameObj.transform.parent = parentTransform;
        LaserRay newLaserRay = newRayGameObj;
        int newBounceValue = laserHit.BounceValue - bounceValue;
        newLaserRay.SetColor(newBounceValue, laserHit.Color); //, laserHit.BounceValue
                                                              //sätt färg och minska bouncevalue
        newLaserRay.BounceValue = newBounceValue;
        newLaserRay.GenerateLaserRay();
        
    }
}
