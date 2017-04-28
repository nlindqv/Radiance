using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pathControl : MonoBehaviour 
{
	public Color rayColor = Color.white;
	public List<Transform> paths = new List<Transform>();
	private float reachDis = 1.0f; 
	Transform [] pos;
	public int CurrentId = 0;
	void OnDrawGizmos()
	{
		Gizmos.color = rayColor;
		pos = GetComponentsInChildren<Transform> ();
		paths.Clear ();

		foreach (Transform path in pos)
		{
			if(path != this.transform)
			{
				paths.Add(path);
			}
		}

		for(int i = 0; i < paths.Count; i++)
		{
			Vector3 position = paths [i].position;
			if (i > 0) {
				Vector3 previous = paths [i - 1].position;
				Gizmos.DrawLine (previous, position);
				Gizmos.DrawWireSphere (position,0.3f);
			}
		}
	}

		
}
