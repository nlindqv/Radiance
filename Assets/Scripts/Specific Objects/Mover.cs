using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour {

	Vector3 prevTransform;
//	float z;

	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}
	void OnTriggerEnter(Collider Other)
	{
		prevTransform = Other.gameObject.transform.position;
//		z = transform.localScale.z;

	}

	void OnTriggerStay(Collider Other)
	{
		prevTransform = Other.gameObject.transform.position;
		Other.gameObject.transform.position = Vector3.MoveTowards (prevTransform, transform.position, 0.1f);
	}
}
