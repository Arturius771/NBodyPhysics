using UnityEngine;

public class RotationController : MonoBehaviour
{
    Rigidbody rigidBody;
    public Vector3 angularVelocity;

    void Start() {
        rigidBody = GetComponent<Rigidbody>();
    }

    void FixedUpdate() {
        Quaternion deltaRotation = Quaternion.Euler(angularVelocity * Time.fixedDeltaTime);
        rigidBody.MoveRotation(rigidBody.rotation * deltaRotation);
    }
}
