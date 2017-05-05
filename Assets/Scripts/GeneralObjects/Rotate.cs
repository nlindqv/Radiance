using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    private bool move;
    public GameObject tool;
    private GameObject activeTool;
    private bool drag;

    private float MoveHeight;

    // Use this for initialization
    void Start()
    {
		MoveHeight = 1.5f;
        move = gameObject.GetComponent<Movable>().getMove();
    }

    // Update is called once per frame
    void Update()
    {
        move = gameObject.GetComponent<Movable>().getMove();
        if (GameManager.gameMode == GameManager.GameMode.mirrorMode && !move && Input.GetMouseButton(0) && activeTool != null)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;            
            if (Physics.Raycast(ray, out hit)  && hit.collider != null && hit.collider.name.Equals(activeTool.name))
            {                
                drag = true;
            }
            else if (!drag)
            {                
                Destroy(activeTool);
            }
        }
        else
        {
            drag = false;
        }
        if (GameManager.gameMode != GameManager.GameMode.mirrorMode) Destroy(activeTool);
    }

    private void OnMouseDown()
    {
        Destroy(activeTool);
    }

    private void OnMouseUp()
    {
		activeTool = Instantiate(tool, new Vector3(transform.position.x, MoveHeight, transform.position.z), Quaternion.Euler(90.0f, 0.0f, 0.0f));
		//activeTool 
        activeTool.GetComponent<RotateTool>().setObject(gameObject.transform);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(activeTool);
    }
}

