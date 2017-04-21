using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainScript : MonoBehaviour {
	
	// Use this for init boiis
	void Start () {
		// directional light
		GameObject light = new GameObject ("The light");

		// create two dir. light components
		Light lightComp1 = light.AddComponent<Light>();
		lightComp1.type = LightType.Directional;
		lightComp1.intensity = 0.65f;
		lightComp1.color = Color.red;
		lightComp1.transform.Rotate (117, -1.2f, -28.4f, Space.World);
		lightComp1.transform.position = new Vector3 (1, 4, 10); 	// position of the extra lighting

		Light lightComp2 = light.AddComponent<Light>();
		lightComp2.type = LightType.Directional;
		lightComp2.intensity = 0.2f;
		lightComp2.color = Color.red;
		lightComp2.transform.Rotate (65, -150, -150, Space.World);
		// lighting color
		lightComp2.transform.position = new Vector3 (32, 8, 8); 	// position of the extra lighting
	}

	// Update is called once per; frame
	void Update () {
		
	}
}
