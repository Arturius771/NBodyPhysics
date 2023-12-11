using UnityEngine;

public class RotationController : MonoBehaviour {
    [SerializeField] private Vector3 angularVelocity;

    void FixedUpdate() {
        Quaternion deltaRotation = Quaternion.Euler(angularVelocity * Time.fixedDeltaTime);

        transform.rotation *= deltaRotation;
    }
}
