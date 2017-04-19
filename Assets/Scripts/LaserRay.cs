using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Laserstråle  {
	// Use this for initialization

    public static void GenereLaserStråle(Vector3 startCordinates, Vector3 direction, LineRenderer laserRay, Color color, int bounceValue)
    {
        Ray ray = new Ray(startCordinates, direction);
        RaycastHit hit;
        laserRay.SetPosition(0, startCordinates);
        Material material = laserRay.material;
        material.color = color;
        if (Physics.Raycast(ray, out hit))
        {
            laserRay.SetPosition(1, hit.point);
        }else{
            laserRay.SetPosition(1, ray.GetPoint(100));
        }
    }
}
