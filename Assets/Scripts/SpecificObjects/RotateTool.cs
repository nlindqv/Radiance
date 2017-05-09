using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateTool : MonoBehaviour {

	public Transform mirror;
    public float rotateSpeed;
    public float baseAngle;

	private Rotate rotate;

    public void setObject(Transform mirror)
    {
        this.mirror = mirror;
		rotate = mirror.GetComponent<Rotate> ();
    }

    private void Start()
    {
        //mirror = gameObject.transform.parent.Find("Mirror").gameObject.transform;
    }

    private void OnMouseDown()
    {
		rotate.SetPrevPosition (mirror.position, mirror.rotation);
        Vector3 pos = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
        baseAngle = Mathf.Atan2(pos.x, pos.y) * Mathf.Rad2Deg;
        baseAngle -= mirror.eulerAngles.y;
		//mirror.GetComponent<Rigidbody> ().detectCollisions.false;
    }

    private void OnMouseDrag()
    {
		Rotate.rotated = true;
        Vector3 pos = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
        float angle = Mathf.Atan2(pos.x, pos.y) * Mathf.Rad2Deg - baseAngle;
        mirror.rotation = Quaternion.AngleAxis(angle, Vector3.up * rotateSpeed);
    }
	/*private void OnMouseUp(){
		mirror.GetComponent<Rigidbody> ().detectCollisions = true;
	}
	*/
}
