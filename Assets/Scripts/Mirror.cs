using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Klass för att hantera reflektion map. spegeln
/// </summary>
[RequireComponent(typeof(Transform))]
public class Mirror : MonoBehaviour, IInteractables
{
    public GameObject ray;
    public int bounceValue;

    public void HandleLaserCollision(LaserRay laserHit)
    {
            //reflektera map. laserns riktningsvektor samt ytans normal
            Vector3 direction = Vector3.Reflect(laserHit.transform.forward, laserHit.HitNormal);
            Transform parentTransform = laserHit.transform.parent;
            GameObject prev = Instantiate(ray, laserHit.HitPoint, Quaternion.LookRotation(direction));
            prev.transform.parent = parentTransform;
            LaserRay newLaser = prev.GetComponent<LaserRay>();
            //sätt färg och minska bouncevalue
            newLaser.BounceValue = laserHit.BounceValue - bounceValue;
            newLaser.Color = laserHit.Color;
    }
}
