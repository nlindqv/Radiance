using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Transform))]
[RequireComponent(typeof(LineRenderer))]
[RequireComponent(typeof(Light))]
public class LaserRay : MonoBehaviour {

    Transform laserPointerTransform;
    LineRenderer laserBeam;
    Light laserFlare;
    public Light BeamHitGlow;
    // Use this for initialization
    void Start () {
        laserPointerTransform = GetComponent<Transform>();
        laserBeam = GetComponent<LineRenderer>();
        laserFlare = GetComponent<Light>();
        laserBeam.enabled = false;
        laserFlare.enabled = false;
        BeamHitGlow.enabled = false;
    }
    
    // Update is called once per frame
    void Update () {
        if (Input.GetMouseButton(0)) {
            StopCoroutine("Fire");
            StartCoroutine("Fire");
        }
    }
    IEnumerator Fire() {
        //Debug.Log("Im running");
        laserBeam.enabled = true;
        laserFlare.enabled = true;

        while (Input.GetMouseButton(0)) {
            Ray laserRay = new Ray(laserPointerTransform.position, laserPointerTransform.forward);
            RaycastHit hit;
            laserBeam.SetPosition(0, laserPointerTransform.position);

            if (Physics.Raycast(laserRay, out hit))
            {
                //laserns startposition
                laserBeam.SetPosition(1, hit.point);
                //flytta (glow)ljuskällan till positionen där lasern träffar
                BeamHitGlow.transform.position = hit.point;
                //flytta (glow)ljuskällan framför eller vid sidan om väggen där lasern pekar
                if ((int)hit.normal.x > 0)
                    BeamHitGlow.transform.position += Vector3.right * 0.10f;
                else if((int)hit.normal.x < 0)
                    BeamHitGlow.transform.position -= Vector3.right * 0.10f;
                else if ((int)hit.normal.z < 0)
                    BeamHitGlow.transform.position -= Vector3.forward * 0.10f;
                //endast då vi träffar ett objekt skall (glow)ljuskällan vara påslagen
                BeamHitGlow.enabled = true;      
            }
            else {
                BeamHitGlow.enabled = false;
                laserBeam.SetPosition(1, laserRay.GetPoint(100));
            }

            yield return null;
        }
        // då muspekaren inte är nedtryckt är lasern avstängd ink. övriga komponenter
        BeamHitGlow.enabled = false;
        laserBeam.enabled = false;
        laserFlare.enabled = false;
    }
}
