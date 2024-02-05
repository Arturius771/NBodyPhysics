using UnityEngine;

public class CameraController : MonoBehaviour {
    public float moveSpeed = 5f;

    void Update() {
        CameraMovement();
    }

    void CameraMovement() {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 moveDirection = new Vector3(horizontalInput, 0, verticalInput).normalized;

        if (moveDirection != Vector3.zero) {
            // Adjust the camera position based on the WASD input
            transform.Translate(moveDirection * moveSpeed * Time.deltaTime, Space.World);
        }

        // RotateCamera();
    }

    //void RotateCamera() {
    //    float horizontalInput = Input.GetAxis("Mouse X");
    //    transform.Rotate(Vector3.up, horizontalInput * rotationSpeed);
    //}
}
