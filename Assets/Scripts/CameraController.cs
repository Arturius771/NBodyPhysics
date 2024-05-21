using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class CameraController : MonoBehaviour {

    // TODO: Create base camera class and inherit
    [SerializeField] private float moveSpeed = 50f;
    [SerializeField] private float rotateSpeedSensitivity = 5f;
    [SerializeField] private int edgeScrollSize = 0;
    [SerializeField] private float dragPanSpeed = 2f;
    [SerializeField] private bool edgePanAllowed = false;
    [SerializeField] private bool dragPanAllowed = false;
    [SerializeField] private float cameraBoundsBox = 3500;

    Vector2 lastMousePosition = new(0, 0);
    private bool dragPanMoveActive = false;
    private new Transform transform;
    private float originalMoveSpeed;

    public GameObject target; // This can probably be private and use a layer name to find this object in the scene

    void Start() {
        transform = this.gameObject.GetComponent<Transform>();
        originalMoveSpeed = moveSpeed;
    }

    void Update() {
        RotateCamera();
        CameraMovement();
        RestrictCamera();
    }

    private void RestrictCamera()
    {
        // (x, y, z)
        transform.position = new(Mathf.Clamp(transform.position.x, -cameraBoundsBox, cameraBoundsBox), transform.position.y, Mathf.Clamp(transform.position.z, -cameraBoundsBox, cameraBoundsBox));
    }

    void CameraMovement() {
        Vector3 inputDir = new(0, 0, 0);

        // Forward
        if (Input.GetKey(KeyCode.W) || Input.mousePosition.y > Screen.height - edgeScrollSize && edgePanAllowed) {
            inputDir.z = +1f;

        }

        // Backward
        if (Input.GetKey(KeyCode.S) || Input.mousePosition.y < edgeScrollSize && edgePanAllowed) {
            inputDir.z = -1f;
        }

        // Left 
        if (Input.GetKey(KeyCode.A) || Input.mousePosition.x < edgeScrollSize && edgePanAllowed) {
            inputDir.x = -1f;
        }

        // Right
        if (Input.GetKey(KeyCode.D) || Input.mousePosition.x > Screen.width - edgeScrollSize && edgePanAllowed) {
            inputDir.x = +1f;
        }


        if (Input.GetMouseButtonDown(2) && dragPanAllowed) {
            dragPanMoveActive = true;
            lastMousePosition = Input.mousePosition;
        }
        if (Input.GetMouseButtonUp(2) && dragPanAllowed) {
            dragPanMoveActive = false;
        }

        if (dragPanMoveActive && dragPanAllowed) {
            Vector2 mouseMovementDelta = (Vector2)Input.mousePosition - lastMousePosition;

            inputDir.x = mouseMovementDelta.x * dragPanSpeed;
            inputDir.z = mouseMovementDelta.y * dragPanSpeed;

            lastMousePosition = Input.mousePosition;
        }

        Vector3 moveDir = transform.forward * inputDir.z + transform.right * inputDir.x;

        if (Input.GetKey(KeyCode.LeftShift) )
        {
            moveSpeed = 3f * originalMoveSpeed;
        }
        else {
            moveSpeed = originalMoveSpeed;
        }

        transform.position += moveSpeed * Time.deltaTime * moveDir;
    }

    void RotateCamera() {
        float rotateDir = 0f;        

        if (Input.GetKey(KeyCode.E)) rotateDir = +1f * rotateSpeedSensitivity;
        if (Input.GetKey(KeyCode.Q)) rotateDir = -1f * rotateSpeedSensitivity;


        transform.RotateAround(target.transform.position, Vector3.up, 20 * Time.deltaTime * rotateDir);
    }
}
