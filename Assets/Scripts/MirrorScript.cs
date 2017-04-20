using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MirrorScript : MonoBehaviour {
	public float mirrWidth; // x component
	public float mirrHeight; // y component
	public float mirrDepth;  // z component
	public GameObject mirror;
	//public Transform mirr;

	// Use this for initialization
	void Start () {
		mirrWidth = 6;
		mirrHeight = 3;
		mirrDepth = 1;
		mirror.transform.localScale = new Vector3 (mirrWidth, mirrHeight, mirrDepth);
	}
	
	// Update is called once per frame
	void Update () {
		mirror.transform.localScale = new Vector3 (mirrWidth, mirrHeight, mirrDepth);
		transform.Rotate (0, 5, 7, Space.World);
	}
}