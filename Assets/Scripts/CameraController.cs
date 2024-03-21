using Unity.VisualScripting;
using UnityEngine;

public class CameraController : MonoBehaviour {
    public float moveSpeed = 5f;
    [SerializeField] private float rotationSpeed = 0.1f;
    [SerializeField] private float zoomSpeed = 5f;
    void Update() {
        RotateCamera();
        ZoomCamera();
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

        //added awesome new feature

    }
    void ZoomCamera()
    {
        float scrollDelta = Input.GetAxis("Mouse ScrollWheel");
       if (scrollDelta != 0)
        {
            Camera.main.fieldOfView -= scrollDelta * zoomSpeed;
            Camera.main.fieldOfView = Mathf.Clamp(Camera.main.fieldOfView, 10f, 60f);



        }
    }
    void RotateCamera()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            transform.Rotate(Vector3.down * rotationSpeed);

        }
        if (Input.GetKey(KeyCode.E))
        {
            transform.Rotate(Vector3.up * rotationSpeed) ;

        }
    }
}
