using UnityEngine;

public class OrbitalVelocityController : MonoBehaviour {

    public Rigidbody targetRigidbody;
    public float initialVelocity;
    public bool calculateOrbitalVelocity = true;
    public bool reverseDirection = false;

    void Start() {

        Rigidbody rigidbody = gameObject.GetComponent<Rigidbody>();
        float gravitationalConstant = GravitationalConstant.g;
        Vector3 direction = rigidbody.position - targetRigidbody.position;
        float distance = direction.magnitude;

        if (targetRigidbody && calculateOrbitalVelocity) {
            initialVelocity = Mathf.Sqrt(gravitationalConstant * targetRigidbody.mass / distance);
        }

        Vector3 appliedInitialVelocity = Vector3.Cross(Vector3.up, direction.normalized) * initialVelocity;

        if (reverseDirection) {
            appliedInitialVelocity = -appliedInitialVelocity;
        }

        rigidbody.AddRelativeForce(appliedInitialVelocity, ForceMode.VelocityChange);
    }
}
