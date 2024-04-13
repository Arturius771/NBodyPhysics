using System.Collections;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.EventSystems;

public class CameraController : MonoBehaviour {

    // TODO: Create base camera class and inherit
    [SerializeField] private float moveSpeed = 50f;
    [SerializeField] private float rotateSpeed = 50f;
    [SerializeField] private int edgeScrollSize = 0;
    [SerializeField] private float dragPanSpeed = 2f;
    [SerializeField] private bool edgePanAllowed = false;
    [SerializeField] private bool dragPanAllowed = false;

    Vector2 lastMousePosition = new(0, 0);
    private bool increaseSpeed = false;
    private bool dragPanMoveActive = false;

    [SerializeField] private GameObject mainCamera;
    public GameObject target;

    void Start() {
        StartCoroutine(IncreaseSpeed());
    }

    void Update() {
        RotateCamera();
        CameraMovement();
    }
    void CameraMovement() {

        Vector3 inputDir = new(0, 0, 0);

        if (Input.GetKey(KeyCode.W) || Input.mousePosition.y > Screen.height - edgeScrollSize && edgePanAllowed) {
            inputDir.z = +1f;
        }

        if (Input.GetKey(KeyCode.S) || Input.mousePosition.y < edgeScrollSize && edgePanAllowed) {
            inputDir.z = -1f;
        }

        if (Input.GetKey(KeyCode.A) || Input.mousePosition.x < edgeScrollSize && edgePanAllowed) {
            inputDir.x = -1f;
        }

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

        transform.position += moveSpeed * Time.deltaTime * moveDir;
    }

    IEnumerator IncreaseSpeed() {
        yield return new WaitForSeconds(.5f);

        if (increaseSpeed) {

            moveSpeed += 100;
        }

        StartCoroutine(IncreaseSpeed());

    }
    void RotateCamera() {
        float rotateDir = 0f;


        

        if (Input.GetKey(KeyCode.E)) rotateDir = +1f;
        if (Input.GetKey(KeyCode.Q)) rotateDir = -1f;

        //transform.eulerAngles += new Vector3(0, rotateDir * rotateSpeed * Time.deltaTime, 0);

        transform.RotateAround(target.transform.position, Vector3.up, 20 * Time.deltaTime * rotateDir);
    }
}
