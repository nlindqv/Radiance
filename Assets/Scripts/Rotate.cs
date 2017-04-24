using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{

    private bool move;
    public GameObject tool;
    private GameObject activeTool;
    private bool drag;

    public float MoveHeight;

    // Use this for initialization
    void Start()
    {
        move = gameObject.GetComponent<MoveObject>().getMove();
    }

    // Update is called once per frame
    void Update()
    {
        move = gameObject.GetComponent<MoveObject>().getMove();

        if (!move && Input.GetMouseButton(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            //Debug.Log(ray);
            if (Physics.Raycast(ray, out hit)  && hit.collider.name.Equals(activeTool.name))
            {
                //Debug.Log(hit.collider.name);
                drag = true;
            }
            else if (!drag)
            {
                //tool.SetActive(false);
                ///Debug.Log("No drag");
                Destroy(activeTool);
            }
        }
        else
        {
            drag = false;
        }
        if (ViewController.gameMode) Destroy(activeTool);
    }

    private void OnMouseDown()
    {
        Destroy(activeTool);
    }

    private void OnMouseUp()
    {
        activeTool = Instantiate(tool, new Vector3(transform.position.x, MoveHeight, transform.position.z), Quaternion.Euler(90.0f, 0.0f, 0.0f));
        activeTool.GetComponent<RotateRing>().setObject(gameObject.transform);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(activeTool);
    }
}

