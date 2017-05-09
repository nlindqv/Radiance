using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MirrorInactive : IInteractables {
	private bool mirrorActive = false;
    private Renderer renderer;
    private Color activeMirrorColor;
    void Start()
    {
        GameObject mirror;
        //hämta objektet spegel och renderer för denna
        mirror = this.transform.parent.GetComponentInChildren<Reflective>().gameObject;
        renderer = mirror.GetComponent<Renderer>();
        // sätt brightness för inaktiv spegel
        renderer.material.SetFloat("_ReflectBrightness", 1f);
        //hämta färg för aktiv spegel
        activeMirrorColor = renderer.material.GetColor("_RimColour");
        //sätt grå färg för inaktiv spegel
        renderer.material.SetColor("_RimColour", Color.gray );
    }

	public override void HandleLaserCollision (LaserRay laserHit){
        // sätt brightness för aktiv spegel
        renderer.material.SetFloat("_ReflectBrightness", 10f);
        //sätt färg för aktiv spegel
        renderer.material.SetColor("_RimColour", activeMirrorColor);
		mirrorActive = true;

		GetComponent<Renderer> ().material.color = new Color32 (27, 57, 154, 255);

	}
	// Return state of locked mirror
	public bool IsActivated(){
		return mirrorActive;
	}
}
