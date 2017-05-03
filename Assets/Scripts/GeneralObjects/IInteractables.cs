using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Interface för föremål/objekt som behöver känna till att de träffats av laser.
/// Observera: föremålen/objekten behöver implementera box collider för att kunna träffas.
/// </summary>
public interface IInteractables
{
    void HandleLaserCollision(LaserRay laserHit);
}
