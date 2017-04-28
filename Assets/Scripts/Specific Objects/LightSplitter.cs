using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Transform))]
public class LightSplitter : MonoBehaviour, IInteractables
{

    public GameObject ray;
    //Color of gate and laserRay-conversion
    public Color Blue;
    public Color Red;
    public Color Green;

    //Use dirty to render new color of gate during gameplay
    public bool dirty;
    private BoxCollider col;
    private Transform child;

    private Vector3 tre = new Vector3(1, 0, 0);
    private Vector3 tre1 = new Vector3(1, 0, -1);
    private Vector3 tre2 = new Vector3(1, 0, 1);

    public int bounceValue;
    void Start()
    {
        col = GetComponent<BoxCollider>();
        foreach (Renderer rend in this.GetComponentsInChildren<Renderer>())
        {
            rend.enabled = true;
            //modify alpha of color
            Blue = new Color(Blue.r, Blue.g, Blue.b, 0.6f);
            rend.material.color = Blue;
            Red = new Color(Red.r, Red.g, Red.b, 0.6f);
            rend.material.color = Red;
            Green = new Color(Green.r, Green.g, Green.b, 0.6f);
            rend.material.color = Green;

        }
    }

    void Update()
    {
        if (dirty)
        {
            UpdateColor();
        }
    }

    void UpdateColor()
    {
        foreach (Renderer rend in this.GetComponentsInChildren<Renderer>())
        {
            rend.enabled = true;
            //modify alpha of color
            Blue = new Color(Blue.r, Blue.g, Blue.b, 0.6f);
            rend.material.color = Blue;

            Red = new Color(Red.r, Red.g, Red.b, 0.6f);
            rend.material.color = Red;

            Green = new Color(Green.r, Green.g, Green.b, 0.6f);
            rend.material.color = Green;
        }
    }


    public void HandleLaserCollision(LaserRay ray)
    {

        Debug.Log(ray.HitNormal.z);
        Transform parentTransform = ray.transform.parent;


        LaserRay newRay = Instantiate(ray, transform.position, Quaternion.LookRotation(tre));
        newRay.transform.parent = parentTransform;
        newRay.SetColor(ray.BounceValue - 1, Blue);
        LaserRay newRay1 = Instantiate(ray, transform.position, Quaternion.LookRotation(tre1));
        newRay1.transform.parent = parentTransform;
        newRay1.SetColor(ray.BounceValue - 1, Red);
        LaserRay newRay2 = Instantiate(ray, transform.position, Quaternion.LookRotation(tre2));
        newRay2.transform.parent = parentTransform;
        newRay2.SetColor(ray.BounceValue - 1, Green);

    }
}