using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Laserstråle  {
	// Use this for initialization

    public static void GenereLaserStråle(Vector3 Startkordinater, Vector3 Riktning, LineRenderer LaserStråle)
    {

        Ray ray = new Ray(Startkordinater, Riktning);
        RaycastHit hit;
        LaserStråle.SetPosition(0, Startkordinater);
        if (Physics.Raycast(ray, out hit))
        {
            LaserStråle.SetPosition(1, hit.point);
        }else{
            LaserStråle.SetPosition(1, ray.GetPoint(100));
        }
    }
}
