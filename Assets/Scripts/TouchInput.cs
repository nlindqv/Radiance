using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchInput : MonoBehaviour
{
	public GameObject laser;
	public Transform ls;
	private float rot;
	private Rigidbody rb;
	private GameObject prev;
	private bool changeDir;
	private Vector2 startPos;
	private Vector2 direction;

	// Use this for initialization
	void Start ()
	{
		rb = GetComponent<Rigidbody> ();
		rot = 0.0f;
	}

	// Update is called once per frame
	void Update ()
	{
		if (Input.touchCount > 0) {
			Touch touch = Input.GetTouch (0);
			switch (touch.phase) {
			case TouchPhase.Began: 
				startPos = touch.position;
				changeDir = false;
				break;
			
			case TouchPhase.Stationary:
				changeDir = false;
				break;
			
			case TouchPhase.Moved:
				direction = startPos - touch.position;
				changeDir = true;
				break;
			
			case TouchPhase.Ended:
				changeDir = false;
				break;

			case TouchPhase.Canceled:
				changeDir = false;
				break;
			}
		}
		if (changeDir) {
			if (direction.y > 0)
				rot += 1.0f;
			else if (direction.y < 0)
				rot -= 1.0f;
		} else
			rot = 0.0f;
		
		Destroy (prev);
		rb.rotation = Quaternion.Euler (0.0f, rot, 0.0f);
		prev = Instantiate (laser, ls.position, ls.position);
	}
