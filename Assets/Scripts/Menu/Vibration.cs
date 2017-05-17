using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Vibration : MonoBehaviour {

	public bool vibration;
	public Selectable toggleButton;

	// Use this for initialization
	void Start () {
		// Check to see if we have stored a value 
		int savedValue = MemoryManager.LoadVibration();
		Debug.Log (savedValue);
		if (savedValue == 2)
			vibration = false;
		else
			vibration = true;
		toggleButton.GetComponent<Toggle>().isOn = vibration;
	}

	/*
     * updateToggleValue will take a bool as argument that corresponds to toggle button value for vibration on toggling gamemodes
     * true -> write 1 to memory
     * false -> write 2 to memory
     */
	public void UpdateToggleValue(bool toggleValue)
	{
		vibration = toggleButton.GetComponent<Toggle>().isOn;
		int vibrationValue;
		if (vibration){
			vibrationValue = 1;
		} else
			vibrationValue = 2;

		MemoryManager.WriteVibration2Memory(vibrationValue);
	}
}