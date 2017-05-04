using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Transform))]
public class LightSplitter :  IInteractables
{
    //Color of gate and laserRay-conversion
    public Color One;
    public Color Two;
    public Color Three;

    private Transform laserOne; 
    private Transform laserTwo; 
    private Transform laserThree; 

    void Start()
    {
        laserOne = this.transform.Find("Spawn1");
        laserTwo = this.transform.Find("Spawn2");
        laserThree = this.transform.Find("Spawn3");
    }

    public void HandleLaserCollision(LaserRay ray)
    {
        Transform parentTransform = ray.transform.parent;        
        LaserRay newRay = Instantiate(ray, laserOne.position, Quaternion.LookRotation(laserOne.up));
        newRay.transform.parent = parentTransform;
        newRay.SetColor(ray.BounceValue - 1, One);
        LaserRay newRay1 = Instantiate(ray, laserTwo.position, Quaternion.LookRotation(laserTwo.up));
        newRay1.transform.parent = parentTransform;
        newRay1.SetColor(ray.BounceValue - 1, Two);
        LaserRay newRay2 = Instantiate(ray, laserThree.position, Quaternion.LookRotation(laserThree.up));
        newRay2.transform.parent = parentTransform;
        newRay2.SetColor(ray.BounceValue - 1, Three);
    }
}