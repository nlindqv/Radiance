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
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;
        laserRay.SetPosition(0, transform.position);
        Material material = laserRay.material;
        material.color = Color;
        if (Physics.Raycast(ray, out hit))
        {
            laserRay.SetPosition(1, hit.point);
        }else{
            laserRay.SetPosition(1, ray.GetPoint(100));
        }
        if (BounceValue <= 0)           // Destory laser ray if bounce value less or equal to 0
            Destroy(this);
    }
}
