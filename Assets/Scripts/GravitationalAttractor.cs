using System.Collections.Generic;
using UnityEngine;

public class GravitationalAttractor : MonoBehaviour
{
    private Rigidbody rigidbody;
    public static List<GravitationalAttractor> bodies;

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
            float force =
                GravitationalConstant.g
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
