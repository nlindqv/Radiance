using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(LineRenderer))]
[RequireComponent(typeof(Transform))]
public class LaserRay : MonoBehaviour
{
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
        //kolla om vi får träff
        if (Physics.Raycast(ray, out hit))
        {
            //sätt publika egenskaper som normal och träffpunkts
            hitPoint = hit.point;
            hitNormal = hit.normal;
            //sätt slutpunkt på lasern
            laserRay.SetPosition(1, hitPoint);
            // kolla om komponenten ugör en interactable
            Component interactableObj = hit.collider.GetComponentInParent(typeof(IInteractables));
            if (interactableObj != null)
            {
                //generera event för laserträff
                ((IInteractables)interactableObj).HandleLaserCollision(this);
            }
        }else{
            laserRay.SetPosition(1, ray.GetPoint(100));
        }
    }
}
