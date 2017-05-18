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
        if (gameObjectsRigidBody.GetComponent<MeshCollider>()) gameObjectsRigidBody.GetComponent<MeshCollider>().enabled = false;
        Renderer objRenderer = trans.gameObject.GetComponent<Renderer>();
        if (objRenderer != null)
        {
            objRenderer.material.SetFloat("_GlossyReflections", 0);
            objRenderer.material.SetFloat("_SpecularHighlights", 0f);
            objRenderer.material.EnableKeyword("_SPECULARHIGHLIGHTS_OFF");   
        }
        gameObjectsRigidBody.freezeRotation = false;
     }

    public static void Float(Transform trans)
    {
        Rigidbody gameObjectsRigidBody = (trans.gameObject.GetComponent<Rigidbody>() == null) ? trans.gameObject.AddComponent<Rigidbody>() : trans.gameObject.GetComponent<Rigidbody>(); // Add the rigidbody.
        if (gameObjectsRigidBody == null) return;
        gameObjectsRigidBody.mass = UnityEngine.Random.Range(0.0f, 10.0f); // Set the GO's mass to 5 via the Rigidbody.
        gameObjectsRigidBody.velocity = new Vector3(UnityEngine.Random.Range(-1.0f, 1.0f), UnityEngine.Random.Range(0.0f, 2.0f), UnityEngine.Random.Range(-1.0f, 1.0f));
        gameObjectsRigidBody.isKinematic = false;
        gameObjectsRigidBody.useGravity = false;
        gameObjectsRigidBody.angularVelocity = new Vector3(UnityEngine.Random.Range(-1.0f, 1.0f), UnityEngine.Random.Range(-1.0f, 1.0f), UnityEngine.Random.Range(-1.0f, 1.0f));
        if (gameObjectsRigidBody.GetComponent<Movable>()) gameObjectsRigidBody.GetComponent<Movable>().enabled = false;
        if (gameObjectsRigidBody.GetComponent<Movable>()) gameObjectsRigidBody.GetComponent<Rotate>().enabled = false;
        if (gameObjectsRigidBody.GetComponent<MeshCollider>()) gameObjectsRigidBody.GetComponent<MeshCollider>().enabled = false;
        gameObjectsRigidBody.freezeRotation = false;
    }
}
