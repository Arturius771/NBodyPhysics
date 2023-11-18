using System.Collections.Generic;
using UnityEngine;

public class GravitationalAttractor : MonoBehaviour
{
    private new Rigidbody rigidbody;
    public static List<GravitationalAttractor> bodies;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = gameObject.GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        foreach (GravitationalAttractor body in bodies) {
            if (body != this) {
                Attract(body);
            }
        }
    }

    void Attract(GravitationalAttractor otherBody) {
        Rigidbody otherRigidBody = otherBody.rigidbody;
        Vector3 direction = otherRigidBody.position - rigidbody.position; 
        float distance = Vector3.Distance(otherRigidBody.position, rigidbody.position);

        if (distance > 0f) {
            float gravitationalConstant = GravitationalConstant.g;
            float force = 
                gravitationalConstant 
                * otherRigidBody.mass 
                * rigidbody.mass 
                / Mathf.Pow(distance, 2); 
            Vector3 appliedForce = force * direction.normalized; 
            rigidbody.AddForce(appliedForce);
        }
    }

    void OnEnable() {
        bodies ??= new List<GravitationalAttractor>();

        bodies.Add(this);
    }

    void OnDisable() {
        bodies.Remove(this);
    }

}
