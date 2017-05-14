using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndScript : MonoBehaviour {

    public static void FloatAway(Transform trans)
    {
        Rigidbody gameObjectsRigidBody = (trans.gameObject.GetComponent<Rigidbody>() == null) ? trans.gameObject.AddComponent<Rigidbody>() : trans.gameObject.GetComponent<Rigidbody>(); // Add the rigidbody.
        if (gameObjectsRigidBody == null) return;
        gameObjectsRigidBody.mass = UnityEngine.Random.Range(0.0f, 10.0f); // Set the GO's mass to 5 via the Rigidbody.
        gameObjectsRigidBody.velocity = new Vector3(UnityEngine.Random.Range(-2.0f, 2.0f), UnityEngine.Random.Range(0.0f, 4.0f), UnityEngine.Random.Range(-2.0f, 2.0f));
        gameObjectsRigidBody.isKinematic = false;
        gameObjectsRigidBody.useGravity = false;
        gameObjectsRigidBody.angularVelocity = new Vector3(UnityEngine.Random.Range(-2.0f, 2.0f), UnityEngine.Random.Range(-2.0f, 2.0f), UnityEngine.Random.Range(-2.0f, 2.0f)) ;
        if (gameObjectsRigidBody.GetComponent<Movable>()) gameObjectsRigidBody.GetComponent<Movable>().enabled = false;
        if (gameObjectsRigidBody.GetComponent<Movable>()) gameObjectsRigidBody.GetComponent<Rotate>().enabled = false;
        gameObjectsRigidBody.freezeRotation = false;
     }
}
