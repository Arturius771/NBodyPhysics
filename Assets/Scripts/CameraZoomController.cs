using UnityEngine;

public class CameraZoomController : MonoBehaviour {
    public float zoomSpeed = 5f;
    public float rotationSpeed = 2f;

    void Update() {
        float scrollWheel = Input.GetAxis("Mouse ScrollWheel");
        if (scrollWheel != 0) {
            ZoomCamera(scrollWheel);
        }
    }

    void ZoomCamera(float scrollDelta) {
        Camera.main.fieldOfView -= scrollDelta * zoomSpeed;
        Camera.main.fieldOfView = Mathf.Clamp(Camera.main.fieldOfView, 10f, 60f);
    }
}
