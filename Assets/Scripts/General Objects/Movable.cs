using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movable : MonoBehaviour
{    
    private Vector3 previousPosition;
    private Quaternion prevRotate;
    private bool move; // Move mode
    private float distance; //Distance moved in display coordinates
    private float startHeight;
    private Rigidbody rigidbody;

    public float moveHeight;

	// Can be applied to any object with a rigidbody
    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        GetComponent<Rigidbody>().freezeRotation = true;
        move = false;
        previousPosition = rigidbody.position;
        startHeight = rigidbody.position.y;
    }
    
    private void OnMouseDown()
    {
        if (!ViewController.gameMode) { // If in mirror mode, pick up mirror
            previousPosition = rigidbody.position;
            prevRotate = transform.rotation;
            distance = Vector3.Distance(rigidbody.position, Camera.main.transform.position);
            move = true;
            
            rigidbody.position = new Vector3(rigidbody.position.x, moveHeight, rigidbody.position.z);
        }

    }

    private void OnMouseDrag()
    {
        if (move && !ViewController.gameMode)	//If in move and mirror mode, enable to move object
        {
            Ray r = Camera.main.ScreenPointToRay(Input.mousePosition);
            Vector3 rayPoint = r.GetPoint(distance);
            rigidbody.position = rayPoint;
            rigidbody.position = new Vector3(rigidbody.position.x, moveHeight, rigidbody.position.z);
        }
    }

    private void OnMouseUp()
    {
        if (!ViewController.gameMode) //If in mirror mode
        {          
            rigidbody.position = new Vector3(rigidbody.position.x, startHeight, rigidbody.position.z);
            move = false;
        }
    }

    private void OnCollisionEnter(Collision col)
    {
		//Move to previous position if collision
        GetComponent<Rigidbody>().position = previousPosition;
        GetComponent<Rigidbody>().velocity = Vector3.zero;
    }

    public bool getMove()
    {
        return move;
    }
}