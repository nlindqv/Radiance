using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotScript1 : MonoBehaviour {


    public Transform mirror;
    public float rotateSpeed;
    Vector3 pos;
    public float baseAngle;
    private void OnMouseDown()
    {
        pos = Input.mousePosition;
        //Debug.Log("Click");
    }

    private void OnMouseDrag()
    {
        Vector3 currentPos = Input.mousePosition - pos;
        baseAngle = Mathf.Atan2(currentPos.x, currentPos.y) * Mathf.Rad2Deg * rotateSpeed;
        mirror.rotation = Quaternion.Euler(0.0f, baseAngle, 0.0f);
        //Debug.Log(baseAngle);
    }


}
