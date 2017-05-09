using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
	private bool move;
	public GameObject tool;
	private GameObject activeTool;
	private bool drag;
	private MirrorInactive activateButton;
	private float MoveHeight;


	public static bool rotated;
	private Transform mirror;
	private Vector3 prevPos;
	private Quaternion prevRotate;


	// Use this for initialization
	void Start ()
	{
		MoveHeight = 1.5f;
		move = gameObject.GetComponent<Movable> ().getMove ();
		if (transform.parent != null)
			activateButton = transform.parent.GetComponentInChildren<MirrorInactive> ();
		 
		mirror = gameObject.transform;
		prevPos = mirror.position;
		prevRotate = mirror.rotation;
}
		
	void Update () {
		move = gameObject.GetComponent<Movable> ().getMove ();
		//if (activateButton == null || activateButton.IsActivated()) {
			if ((GameManager.gameMode == GameManager.GameMode.mirrorMode && !move && Input.GetMouseButton (0) && activeTool != null)&&(activateButton == null || activateButton.IsActivated())) {
				Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
				RaycastHit hit;            
				if (Physics.Raycast (ray, out hit) && hit.collider != null && hit.collider.name.Equals (activeTool.name)) {                
					drag = true;
				} else if (!drag) {                
					Destroy (activeTool);
				}
			} else {
				drag = false;
			}
			if (GameManager.gameMode != GameManager.GameMode.mirrorMode)
				Destroy (activeTool);
		//}

		// om prev och nuvarande är olika om rotate är true
		if (rotated && !prevPos.Equals (transform.position)) {
			transform.position = this.prevPos;
			transform.rotation = this.prevRotate;
			Destroy (activeTool);

		}
	}

	private void OnMouseDown ()
	{
			Destroy (activeTool);
	}

	private void OnMouseUp ()
	{
		if (activateButton == null || activateButton.IsActivated()){
			activeTool = Instantiate (tool, new Vector3 (transform.position.x, MoveHeight, transform.position.z), Quaternion.Euler (90.0f, 0.0f, 0.0f));
		//activeTool 
		activeTool.GetComponent<RotateTool> ().setObject (gameObject.transform);
		}
	}

	private void OnCollisionEnter (Collision collision)
	{
		if (!collision.collider.name.Equals ("Plane")){
			if (rotated) {
				Debug.Log ("Rotate collision");
				Debug.Log (prevPos);
				Debug.Log (prevRotate);
				mirror.position = this.prevPos;
				mirror.rotation = this.prevRotate;
				mirror.GetComponent<Rigidbody> ().freezeRotation = true;
			}
			else
				Destroy (activeTool);
			}
	}
	public void SetPrevPosition(Vector3 prevPos, Quaternion prevRotate){
		this.prevPos = prevPos;
		this.prevRotate = prevRotate;
	}
}

