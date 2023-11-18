using UnityEngine;

public class VelocityController : MonoBehaviour {

    public bool calculateOrbitalVelocity = true;
    public Rigidbody targetRigidbody;
    public float velocity;
    public float gravitationalConstant = GravitationalConstant.g;

    private Rigidbody rigidBody;

    void Start() {
        rigidBody = gameObject.GetComponent<Rigidbody>();

        if (targetRigidbody && calculateOrbitalVelocity) {
            Vector3 direction = (targetRigidbody.position - rigidBody.position).normalized;

            velocity = Mathf.Sqrt(gravitationalConstant * targetRigidbody.mass / direction.magnitude);
        }

        rigidBody.AddForce(velocity * Time.fixedDeltaTime, 0, 0, ForceMode.Impulse);
    }
}
