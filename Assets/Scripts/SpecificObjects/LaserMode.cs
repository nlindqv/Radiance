using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserMode : MonoBehaviour
{
    public GameObject Plane;
    public GameObject laser;
    public Transform ls;
    private Camera mainCamera;
    private Transform rb;
    public LaserStack laserStack;

    bool next;
    private Vector3 prevDirection;

    bool first = true;
    // Use this for initialization
    void Start()
    {
        mainCamera = Camera.main;
        rb = GetComponent<Transform>();
        //StartCoroutine("FireLaser");
    }

    private Vector3 CalculateDirectionVector(Vector3 hitPoint)
    {
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
        return forwardUnit + rightUnit;
    }
    /// <summary>
    /// Ger det träffade planet som Rayen träffat
    /// </summary>
    /// <param name="ray">Ray att använda för att träffa planet</param>
    /// <returns>Det kordinater för träffade planet</returns>
    private Vector3? GetHitPointPlane(Ray ray)
    {
        RaycastHit[] hit = Physics.RaycastAll(ray);
        if (hit.Length > 0)
        {
            for (int i = 0; i < hit.Length; i++)
            {
                Component hitPlane = hit[i].collider.GetComponentInParent(typeof(Plane));
                if (hitPlane != null) return hit[i].point;
            }
        }
        return null;
    }
    /// <summary>
    /// Sätter föregående riktningsvektor från vilken vinkeln kommer beräknas
    /// </summary>
    /// <returns>Boolean indikerar om föregående riktningsvektorn är satt</returns>
    private bool SetPreviousDirectionVector()
    {
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        Vector3? planeHitPoint = GetHitPointPlane(ray);
        if (planeHitPoint != null)
        {
            // beräkna föregående riktningsvektor om ett plan träffats
            prevDirection = CalculateDirectionVector(planeHitPoint.Value);
            return true; // indikera träff på plan
        }
        else return false; // indikera ingen träff på plan

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        StopCoroutine("FireLaser");
        StartCoroutine("FireLaser");
    }

    IEnumerator FireLaser()
    {
        float angle = 0;
        if (GameManager.gameMode == GameManager.GameMode.laserMode)
        { //Enable laser mode	
            if (Input.GetMouseButtonDown(0))
            {
                //sätt föregående riktningsvektor och indikera att nästa frame skall generera riktningsvektor där vinkeln kan beräknas
                if (SetPreviousDirectionVector())
                    next = true;
                yield return null;
            }
            else if (Input.GetMouseButton(0) && !next)
            {
                //sätt föregående riktningsvektor och indikera att nästa frame skall generera riktningsvektor där vinkeln kan beräknas
                if (SetPreviousDirectionVector())
                    next = true;
                yield return null;
            }
            else if ((Input.GetMouseButton(0) && next))
            { //|| Input.GetMouseButtonUp(0)
                Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
                Vector3? planeHitPoint = GetHitPointPlane(ray);
                if (planeHitPoint != null)
                {
                    Vector3 currentDirection = CalculateDirectionVector(planeHitPoint.Value);
                    //beräkna vinkel mellan föregående riktningsvektor och nuvarande
                    angle = Vector3.Angle(prevDirection, currentDirection);

                    // kontrollera tecken på vinkeln med hjälp av kryssprodukten
                    rb.eulerAngles += new Vector3(0, angle) * Mathf.Sign(Vector3.Cross(prevDirection, currentDirection).y);
                    next = false;
                }
            }
        }

        while (ls.transform.childCount > 0)
        {
            Transform child = ls.transform.GetChild(0);
            child.SetParent(null);
            child.gameObject.SetActive(false);
            laserStack.push(child.gameObject.GetComponent<LaserRay>());
        }

        //skapa ny laserstråle
        LaserRay newLaser = laserStack.pop();//Instantiate(laser, rb.position, rb.rotation);
        newLaser.transform.parent = ls.transform;
        newLaser.transform.position = rb.position;
        newLaser.transform.rotation = rb.rotation;
        newLaser.SetColor(newLaser.BounceValue, Color.red);
        newLaser.GenerateLaserRay();
    }
}
