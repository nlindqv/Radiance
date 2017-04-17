using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Transform))]
public class LaserController : MonoBehaviour {
    Transform laserTransform;
    public Camera MainCamera;
    // Use this for initialization
    void Start () {
        laserTransform = GetComponent<Transform>();
    }
    
    // Update is called once per frame
    void Update () {
        if (Input.GetMouseButton(0)) {
            Ray ray = MainCamera.ScreenPointToRay(Input.mousePosition);
            Vector3 mouseNear = Input.mousePosition;
            mouseNear.z = MainCamera.nearClipPlane;
            mouseNear = MainCamera.ScreenToWorldPoint(mouseNear);
            Vector3 mouseFar = Input.mousePosition;
            mouseFar.z = MainCamera.farClipPlane;
            mouseFar = MainCamera.ScreenToWorldPoint(mouseFar);
            Debug.DrawRay(ray.origin, ray.direction * 10, Color.yellow);
            Debug.DrawRay(mouseNear,  mouseFar-mouseNear, Color.green); 
            RaycastHit hit;
            float angle;
            if (Physics.Raycast(ray,out hit)) {
                //angle i vanliga radianer
                angle = Mathf.Acos(hit.point.normalized.x);
                // angle med hänsyn till ursprungsrotering i laserpekare (90 => pi/2)
                angle = Mathf.PI / 2 - angle;
                //omvandling till grader
                angle =  angle*180/Mathf.PI;
                laserTransform.eulerAngles = Vector3.up * angle;  
            }
        }
    }
}
