using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MirrorInactive : IInteractables {
	private bool mirrorActive = false;

	public override void HandleLaserCollision (LaserRay laserHit){
		mirrorActive = true;
	}
	// Return state of locked mirror
	public bool IsActivated(){
		return mirrorActive;
	}
}
