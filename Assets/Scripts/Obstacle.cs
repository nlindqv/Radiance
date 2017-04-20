using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour {

    public GameObject obstacle;
    public float width;
    public float rotationValue;

    private Rigidbody rb;

    private void Start()
    {
        width = 2;
        rotationValue = 0;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update () {
        // to change width of the obstacle
        obstacle.transform.localScale = new Vector3(width, 2, 0.5f);

        // to rotate the obstacle
        rb.rotation = Quaternion.Euler(0.0f, rotationValue, 0.0f);  // set rigid body's rotation
    }


}
