using UnityEngine;

public class OrbitalVelocityController : MonoBehaviour {

    [SerializeField] private Rigidbody targetRigidbody;
    [SerializeField] private float initialVelocity;
    [SerializeField] private bool calculateOrbitalVelocity = true;
    [SerializeField] private bool reverseDirection = false;

    void Start() {
        CalculateVelocity();
        
    }

    private void OnEnable() {
        CalculateVelocity();
    }

    private void CalculateVelocity() {
        Rigidbody rigidbody = gameObject.GetComponent<Rigidbody>();
        Vector3 direction = rigidbody.position - targetRigidbody.position;
        float distance = direction.magnitude;

        if (targetRigidbody && calculateOrbitalVelocity) {
            initialVelocity = Mathf.Sqrt(GravitationalConstant.g * targetRigidbody.mass / distance);
        }

        Vector3 appliedInitialVelocity = Vector3.Cross(Vector3.up, direction.normalized) * initialVelocity;

        if (reverseDirection) {
            appliedInitialVelocity = -appliedInitialVelocity;
        }

        rigidbody.AddRelativeForce(appliedInitialVelocity, ForceMode.VelocityChange);
    }
}
