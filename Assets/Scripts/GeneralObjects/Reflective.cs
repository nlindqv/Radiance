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
    public int bounceValue;

    public override void HandleLaserCollision(LaserRay laserHit)
    {
        int newBounceValue = laserHit.BounceValue - bounceValue;  

        //reflektera map. laserns riktningsvektor samt ytans normal
        Vector3 direction = Vector3.Reflect(laserHit.transform.forward, laserHit.HitNormal);
        Transform parentTransform = laserHit.transform.parent;        
        LaserRay newLaserRay = GetLaser(newBounceValue);                    // Get laser 
        if (newLaserRay == null) return;
        newLaserRay.transform.parent = parentTransform;
        //sätt färg och minska bouncevalue
        newLaserRay.SetColor(newBounceValue, laserHit.Color);
        newLaserRay.transform.position = laserHit.HitPoint;
        newLaserRay.transform.rotation = (Quaternion.LookRotation(direction));
        newLaserRay.GenerateLaserRay();        
    }
}
