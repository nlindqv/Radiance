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

    private Vector3 hitPoint;
    private Vector3 hitNormal;
    public Vector3 HitPoint { get { return hitPoint; } }
    public Vector3 HitNormal { get { return hitNormal; } }

	// Use this for initialization
    void Start()
    {
        laserRay = GetComponent<LineRenderer>();
        transform = GetComponent<Transform>();
        if (BounceValue > 0) GenerateLaserRay();
    }
    public void GenerateLaserRay()
    {
        Vector3 direction = transform.forward;
        Ray ray = new Ray(transform.position, direction);
        RaycastHit hit;
        laserRay.SetPosition(0, transform.position);
        Material material = laserRay.material;
        material.color = Color;
        if (Physics.Raycast(ray, out hit))
        {
            hitPoint = hit.point;
            hitNormal = hit.normal;
            laserRay.SetPosition(1, hitPoint);
            Component interactableObj = hit.collider.GetComponentInParent(typeof(IInteractables));
            if (interactableObj != null)
            {
                ((IInteractables)interactableObj).HandleLaserCollision(this);
            }
        }else{
            laserRay.SetPosition(1, ray.GetPoint(100));
        }
        if (BounceValue <= 0)           // Destory laser ray if bounce value less or equal than 0
            Destroy(this);
    }
}
