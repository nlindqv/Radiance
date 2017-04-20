using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchInput : MonoBehaviour
{
	public GameObject laser;
	public Transform ls;

	private float rot;
	private Rigidbody rb;
	private GameObject previousLaser;
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

            // only consider the first touch on the screen
			Touch touch = Input.GetTouch (0);

			switch (touch.phase) {

			case TouchPhase.Began: 
				startPos = touch.position;
				changeDir = false;
				break;
			
			case TouchPhase.Stationary:
                startPos = touch.position;
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
			if (direction.y > 8)
				rot += 2.5f;
			else if (direction.y < -8)
				rot -= 2.5f;
		}
        
		Destroy (previousLaser);
        // if rotation should depend on both x and y 
        /*
        float angle = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg * 0.3f;
        rb.rotation = Quaternion.Euler(0.0f, angle, 0.0f);
        */

        rb.rotation = Quaternion.Euler (0.0f, rot, 0.0f);
		previousLaser = Instantiate (laser, ls.position, ls.rotation);

    }
}
