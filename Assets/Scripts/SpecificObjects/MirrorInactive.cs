using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MirrorInactive : IInteractables {
	private bool mirrorActive = false;

	public override void HandleLaserCollision (LaserRay laserHit){
		mirrorActive = true;

		GetComponent<Renderer> ().material.color = new Color32 (27, 57, 154, 255);

	}
	// Return state of locked mirror
	public bool IsActivated(){
		return mirrorActive;
	}
}
