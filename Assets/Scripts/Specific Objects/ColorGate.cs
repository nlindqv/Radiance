using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorGate : MonoBehaviour {

    public Color color;

    private BoxCollider col;
    private Transform child; 

	// Use this for initialization
	void Start () {
        col = GetComponent<BoxCollider>();
        foreach (Renderer rend in this.GetComponentsInChildren<Renderer>())
        {
            rend.material.color = color;          
        }
        Vector3 scale = this.transform.Find("GateModel").gameObject.transform.localScale;
        Debug.Log(scale);
        col.size =  new Vector3(0.0f, scale.y, scale.z);    

	}
}
