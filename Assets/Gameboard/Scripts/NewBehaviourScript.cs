using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour {

    public GameObject gameField;
    public float gameFieldHeight;
    public float gameFieldWidth;

	// Use this for initialization
	void Start () {
        gameFieldHeight = 1;
        gameFieldWidth = 3;
        gameField.transform.localScale = new Vector3(gameFieldWidth, 1, gameFieldHeight);

    }
	
	// Update is called once per frame
	void Update () {
        gameField.transform.localScale = new Vector3(gameFieldHeight, 1, gameFieldWidth);
    }
}
