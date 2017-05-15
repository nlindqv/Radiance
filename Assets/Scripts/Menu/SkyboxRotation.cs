using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyboxRotation : MonoBehaviour {

	// Update is called once per frame
	void Update () {
		RenderSettings.skybox.SetFloat("_Rotation", 2 * Time.deltaTime + RenderSettings.skybox.GetFloat("_Rotation"));
		RenderSettings.skybox.SetFloat("_Exposure", Mathf.Sin(Time.deltaTime / 4.0f + RenderSettings.skybox.GetFloat("_Rotation"))/8.0f + 0.7f);
		Debug.Log(RenderSettings.skybox.GetFloat("_Exposure"));
		//RenderSettings.skybox = skybox;

	}
}
