using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Interface för föremål/objekt som behöver känna till att de träffats av laser.
/// Observera: föremålen/objekten behöver implementera box collider för att kunna träffas.
/// </summary>
public abstract class IInteractables : MonoBehaviour
{
    public   LaserStack laserStack;
    //public LaserRay ray;

    public virtual void HandleLaserCollision(LaserRay laserHit) {
        Debug.Log("Hit");
            }      
    

    public void SetLasers(LaserStack laserStack) {
        this.laserStack = laserStack;
    }  

    /*public LaserRay GetLaser()
    {
        LaserRay newRayGameObj;
        if (laserStack.size() == 0)
        {
            newRayGameObj = Instantiate(ray, Vector3., Quaternion.LookRotation(direction)).GetComponent<LaserRay>();
        }
        else
        {
            newRayGameObj = laserStack.pop();
            newRayGameObj.transform.position = laserHit.HitPoint;
            newRayGameObj.transform.rotation = Quaternion.LookRotation(direction);
        }
    } */
}
