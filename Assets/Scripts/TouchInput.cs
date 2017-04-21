using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchInput : MonoBehaviour
{
    public GameObject Plane;
    public GameObject laser;
    public Transform ls;
    public Camera mainCamera;

    private Transform rb;
    private GameObject previousLaser;

    bool next;
    private Vector3 prevDirection;
    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Transform>();
    }

    private Vector3 CalculateDirectionVector(Vector3 hitPoint) {
        //hämta planets kordinatssystem
        Transform planeTransform = Plane.GetComponent<Transform>();
        // riktningvektor i 3D
        Vector3 direction = hitPoint - rb.position;
        //projecera riktningsvektorn på planet
        // i Z-led
        Vector3 forwardUnit = Vector3.Project(direction, planeTransform.forward);
        // i X-led
        Vector3 rightUnit = Vector3.Project(direction, planeTransform.right);
        // beräkna ny riktningsvektor
        return  forwardUnit + rightUnit;
    }

    private bool SetPreviousDirectionVector() {
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            // beräkna föregående riktningsvektor
            prevDirection = CalculateDirectionVector(hit.point);
            return true; // indikera träff på plan
        }
        return false; // indikera ingen träff på plan
    }
    
    // Update is called once per frame
    void Update()
    {
        float angle = 0;
        if (Input.GetMouseButtonDown(0))
        {
            //sätt föregående riktningsvektor och indikera att nästa frame skall generera riktningsvektor där vinkeln kan beräknas
            if (SetPreviousDirectionVector()) next = true;
        }
        else if (Input.GetMouseButton(0) && !next)
        {
            //sätt föregående riktningsvektor och indikera att nästa frame skall generera riktningsvektor där vinkeln kan beräknas
            if (SetPreviousDirectionVector()) next = true;
        }
        else if ((Input.GetMouseButton(0) && next)) //|| Input.GetMouseButtonUp(0)
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                Vector3 currentDirection = CalculateDirectionVector(hit.point);
                //beräkna vinkel mellan föregående riktningsvektor och nuvarande
                angle = Vector3.Angle(prevDirection, currentDirection);

                // kontrollera tecken på vinkeln med hjälp av kryssprodukten
                rb.eulerAngles += new Vector3(0, angle) * Mathf.Sign(Vector3.Cross(prevDirection, currentDirection).y);
                next = false;
            }

        }
  
        Destroy(previousLaser);
        previousLaser = Instantiate(laser, ls.position, ls.rotation);
    }
}
