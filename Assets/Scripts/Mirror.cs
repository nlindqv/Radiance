using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Klass för att hantera reflektion map. spegeln
/// </summary>
[RequireComponent(typeof(Transform))]
public class Mirror : MonoBehaviour, IInteractables
{
    private GameObject prev;
    public GameObject ray;
    public int bounceValue;
    private Transform objTransform;

    public float mirrWidth; // x component
    public float mirrHeight; // y component
    public float mirrDepth;  // z component

    private Vector3 previousPosition;
    private bool move;
    public GameObject rotateTool;
    private GameObject tool;
    private float time;
    public float delay;
    private float speed = 2.0f;
    private float distance;
    private bool drag;

    // Use this for initialization
    void Start () {
        objTransform = GetComponent<Transform>();
        mirrWidth = 6;
        mirrHeight = 3;
        mirrDepth = 1;
        transform.localScale = new Vector3(mirrWidth, mirrHeight, mirrDepth);
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        Destroy(prev);
    }

    private void Update()
    {
        if (!move && Input.GetMouseButton(0))
        {
            Debug.Log("Click");
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            Debug.Log(ray);
            if (Physics.Raycast(ray, out hit) && hit.collider.name == "ring")
                drag = true;
            else if (!drag)
                Destroy(tool);
        }
        else
        {
            drag = false;            
        }
        
    }

    private void OnMouseDown()
    {
        previousPosition = transform.position;
        distance = Vector3.Distance(transform.position, Camera.main.transform.position);
        move = true;
        time = Time.time;
        if (tool != null)
            Destroy(tool);
    }

    private void OnMouseUp()
    {
        move = false;
        drag = false;
        // Open tool 
        tool = Instantiate(rotateTool, new Vector3(transform.position.x, transform.position.y + 5.0f, transform.position.z), gameObject.transform.rotation);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Not good");
    }

    private void OnCollisionStay(Collision collision)
    {        
        if (!move)
        {
            transform.position = previousPosition;
        }
    }

    private void OnMouseDrag()
    {
        if (Time.time > time + delay && move) {
            Ray r = Camera.main.ScreenPointToRay(Input.mousePosition);
            Vector3 rayPoint = r.GetPoint(distance);
            transform.position = rayPoint;
            transform.position = new Vector3(transform.position.x, 0.0f, transform.position.z);
        }

        drag = true;
    }

    

    public void HandleLaserCollision(LaserRay laserHit)
    {        
        //reflektera map. laserns riktningsvektor samt ytans normal
        Vector3 direction = Vector3.Reflect(laserHit.transform.forward,laserHit.HitNormal);
        prev = Instantiate(ray, laserHit.HitPoint, Quaternion.LookRotation(direction));
        LaserRay newLaser = prev.GetComponent<LaserRay>();
        //sätt färg och minska bouncevalue
        newLaser.BounceValue = laserHit.BounceValue- bounceValue;
        newLaser.Color = laserHit.Color;
         
    }
}
