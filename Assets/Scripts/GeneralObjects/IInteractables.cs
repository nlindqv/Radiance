using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Interface för föremål/objekt som behöver känna till att de träffats av laser.
/// Observera: föremålen/objekten behöver implementera box collider för att kunna träffas.
/// </summary>
public abstract class IInteractables : MonoBehaviour
{
    [HideInInspector]
    public LaserStack laserStack;
    [HideInInspector]
    public LaserRay ray;
    
    public virtual void HandleLaserCollision(LaserRay laserHit)
    {
        Debug.Log("Hit");
    }

    public virtual void HandleUpdate()
    {
        Debug.Log("Reversed hit");
    }

    public void SetLasers(LaserStack laserStack)
    {
        this.laserStack = laserStack;
    }

    public void SetLaser(LaserRay laser)
    {
        this.ray = laser;
    }

    public LaserRay GetLaser(int value)
    {
        if (laserStack != null) return Instantiate(ray, Vector3.zero, Quaternion.identity).GetComponent<LaserRay>();
        LaserRay newRayGameObj = (laserStack.size() <= 0) ? Instantiate(ray, Vector3.zero, Quaternion.identity).GetComponent<LaserRay>() : laserStack.pop();
        return newRayGameObj;
    } 
}
