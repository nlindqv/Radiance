using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiddleMenu : MonoBehaviour {
	public static string select;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Replay () {
		select = "replay";
	}
	public void Next () {
		select = "next";
	}
	public void Menu () {
		select = "menu";
	}
}
