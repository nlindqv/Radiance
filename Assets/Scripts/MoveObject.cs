using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject : MonoBehaviour
{
    
    private Vector3 previousPosition;
    private Quaternion prevRotate;
    private bool move;
    private float distance;

    public float MoveHeight;

    private void Start()
    {
        GetComponent<Rigidbody>().freezeRotation = true;
    }
  
    private void OnMouseDown()
    {
        previousPosition = transform.position;
        prevRotate = transform.rotation;
        distance = Vector3.Distance(transform.position, Camera.main.transform.position);
        move = true;
        transform.position = new Vector3(transform.position.x, MoveHeight, transform.position.z);
    }

    private void OnMouseDrag()
    {
        if (move)
        {
            Ray r = Camera.main.ScreenPointToRay(Input.mousePosition);
            Vector3 rayPoint = r.GetPoint(distance);
            transform.position = rayPoint;
            transform.position = new Vector3(transform.position.x, MoveHeight, transform.position.z);
        }
    }

    private void OnMouseUp()
    {     
        transform.position = new Vector3(transform.position.x, 0.0f, transform.position.z);
        move = false;
    }

    private void OnCollisionEnter(Collision col)
    {
        GetComponent<Rigidbody>().position = previousPosition;
        GetComponent<Rigidbody>().velocity = Vector3.zero;
    }
}