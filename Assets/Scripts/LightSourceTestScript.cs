using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSourceTestScript : MonoBehaviour {

	public GameObject laser;
	public Transform ls;
	private Rigidbody rb;
	private GameObject prev;
	private float rot;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
		rot = 0.0f;


	}
	
	// Update is called once per frame
	void Update () {
		/* to be able to rotate the laser -> destroy prev laser and init new with new rotation/position
		when an obstacle is in the way of the laser, destroying and creating new lasers solves the problem with updating them
		*/
		Destroy (prev); 
		// code under is to test the rotation
		rb.rotation = Quaternion.Euler(0.0f, rot, 0.0f);  // set rigid body's rotation
		rot += 1.0f;  // increase rotation
		prev = Instantiate (laser, ls.position, ls.rotation);

	}
}
