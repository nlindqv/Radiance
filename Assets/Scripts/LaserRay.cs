using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(LineRenderer))]
[RequireComponent(typeof(Transform))]
public class LaserRay : MonoBehaviour
{
    //public Vector3 Direction;
    public Color Color;
    public int BounceValue;
    private Vector3 startCordinates;
    private LineRenderer laserRay;
    private Transform transform;

	// Use this for initialization
    void Start()
    {
        laserRay = GetComponent<LineRenderer>();
        transform = GetComponent<Transform>();
        if (BounceValue > 0) GenerateLaserRay();
    }
    public void GenerateLaserRay()
    {
        Ray ray = new Ray(startCordinates,transform.forward);
        RaycastHit hit;
        laserRay.SetPosition(0, startCordinates);
        Material material = laserRay.material;
        material.color = Color;
        if (Physics.Raycast(ray, out hit))
        {
            laserRay.SetPosition(1, hit.point);
        }else{
            laserRay.SetPosition(1, ray.GetPoint(100));
        }
    }
}
