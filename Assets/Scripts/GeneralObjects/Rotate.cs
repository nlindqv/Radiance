﻿using System.Collections;
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

    public bool rotated;
    private Transform mirror;
    private Vector3 prevPos;
    private Quaternion prevRotate;
    private Quaternion prevRotation;

    // Use this for initialization
    void Start()
    {
        MoveHeight = 2.0f;
        move = gameObject.GetComponent<Movable>().getMove();
        if (transform.parent != null)
			activateButton = transform.parent.GetComponentInChildren<MirrorInactive> ();

        mirror = gameObject.transform;
        prevPos = mirror.position;
        prevRotate = mirror.rotation;
    }

    void Update()
    {
        move = gameObject.GetComponent<Movable>().getMove();
        if (activateButton == null || activateButton.IsActivated()) {
        if ((GameManager.gameMode == GameManager.GameMode.mirrorMode && !move && Input.GetMouseButton(0) && activeTool != null) && (activateButton == null || activateButton.IsActivated()))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit) && hit.collider != null && hit.collider.name.Equals(activeTool.name))
            {
                drag = true;
            }
            else if (!drag)
            {
                Destroy(activeTool);
                //rotated = false;
                SetPrevPosition(mirror.position, mirror.rotation);
            }
        }
        else
        {
            drag = false;
        }
        if (GameManager.gameMode != GameManager.GameMode.mirrorMode)
            Destroy(activeTool);
        }

        // om prev och nuvarande är olika om rotate är true
        /*bool x = NearlyEqual(prevPos.x, transform.position.x, 0.001f);
        bool y = NearlyEqual(prevPos.y, transform.position.y, 0.001f);
        bool z = NearlyEqual(prevPos.z, transform.position.z, 0.001f);

        if (rotated && (!x || !y || !z))
        {
            transform.position = this.prevPos;
            transform.rotation = this.prevRotate;
            Destroy(activeTool);
        }*/
    }

    private void OnMouseDown()
    {
        Destroy(activeTool);
    }

    private void OnMouseUp()
    {
        if (activateButton == null || activateButton.IsActivated())
        {
            activeTool = Instantiate(tool, new Vector3(transform.position.x, MoveHeight, transform.position.z), Quaternion.Euler(90.0f, 0.0f, 0.0f));
            //activeTool 
            activeTool.GetComponent<RotateTool>().setObject(gameObject.transform);
            //rotated = true;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        prevRotation = GetComponent<Rigidbody>().rotation;
    }

    private void OnCollisionStay(Collision collision)
    {
        /*if (!collision.collider.name.Equals("Plane"))
        {
            if (rotated)
            {
                Debug.Log("Rotate collision");
                Debug.Log(prevPos);
                Debug.Log(prevRotate);
                mirror.position = this.prevPos;
                mirror.rotation = this.prevRotate;
                mirror.GetComponent<Rigidbody>().freezeRotation = true;
            }
           // else
               // Destroy(activeTool);
        }*/
        //Debug.Log("Stuck!");
        //transform.Rotate(Vector3.up * 100.0f, Space.World);
        //rigidbody
    }

    private void OnCollisionExit(Collision collision)
    {
       // GetComponent<Rigidbody>().rotation = prevRotation;
    }

    public void SetPrevPosition(Vector3 prevPos, Quaternion prevRotate)
    {
        this.prevPos = prevPos;
        this.prevRotate = prevRotate;
    }

    public static bool NearlyEqual(float a, float b, float epsilon)
    {
        float absA = Mathf.Abs(a);
        float absB = Mathf.Abs(b);
        float diff = Mathf.Abs(a - b);

        if (a == b)
        { // shortcut, handles infinities
            return true;
        }
        else if (a == 0 || b == 0 || diff < float.Epsilon)
        {
            // a or b is zero or both are extremely close to it
            // relative error is less meaningful here
            return diff < epsilon;
        }
        else
        { // use relative error
            return diff / (absA + absB) < epsilon;
        }
    }
}
