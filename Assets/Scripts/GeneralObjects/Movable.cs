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
    private Rigidbody rigidb;
	private Vector3 distanceOffset;
	private Vector3 rayPoint;
	private Ray r;

    public float moveHeight;

	// Can be applied to any object with a rigidbody
    private void Start()
    {
        rigidb = GetComponent<Rigidbody>();
        GetComponent<Rigidbody>().freezeRotation = true;
        move = false;
        previousPosition = rigidb.position;
        startHeight = rigidb.position.y;
    }
    
    private void OnMouseDown()
    {
        if (GameManager.gameMode == GameManager.GameMode.mirrorMode) { // If in mirror mode, pick up mirror
            previousPosition = rigidb.position;
			prevRotate = transform.rotation;
            move = true;
            rigidb.position = new Vector3(rigidb.position.x, moveHeight, rigidb.position.z);
			updateTouchPoint ();
			distanceOffset = rayPoint - previousPosition;
        }

    }

    private void OnMouseDrag()
    {
        if (move && GameManager.gameMode == GameManager.GameMode.mirrorMode)	//If in move and mirror mode, enable to move object
        {
			updateTouchPoint ();
 			rigidb.position = rayPoint - distanceOffset;
			rigidb.position = new Vector3(rigidb.position.x, moveHeight, rigidb.position.z);
			}
    }

    private void OnMouseUp()
    {
        if (GameManager.gameMode == GameManager.GameMode.mirrorMode) //If in mirror mode
        {          
            rigidb.position = new Vector3(rigidb.position.x, startHeight, rigidb.position.z);
            move = false;
        }
    }

	private void updateTouchPoint (){
		r = Camera.main.ScreenPointToRay(Input.mousePosition);
		distance = Vector3.Distance(rigidb.position, Camera.main.transform.position);
		rayPoint = r.GetPoint(distance);
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