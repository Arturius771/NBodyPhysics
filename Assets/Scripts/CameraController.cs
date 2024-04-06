using System.Collections;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.EventSystems;

public class CameraController : MonoBehaviour {

    // TODO: Create base camera class and inherit
    [SerializeField] private float moveSpeed = 50f;
    [SerializeField] private float rotateSpeed = 100f;
    [SerializeField] private int edgeScrollSize = 20;
    [SerializeField] private float dragPanSpeed = 2f;
    Vector2 lastMousePosition = new(0, 0);
    private bool increaseSpeed = false;
    private bool dragPanMoveActive = false;

    void Update() {
        RotateCamera();
        CameraMovement();
    }

    void Start()
    {
        StartCoroutine(IncreaseSpeed());
    }
    
    void CameraMovement() {

        Vector3 inputDir = new(0, 0, 0);
        
        if (Input.GetKey(KeyCode.W) || Input.mousePosition.y > Screen.height - edgeScrollSize) {
            inputDir.z = +1f;
        }

        if (Input.GetKey(KeyCode.S) || Input.mousePosition.y < edgeScrollSize) {
            inputDir.z = -1f;
        }

        if (Input.GetKey(KeyCode.A) || Input.mousePosition.x < edgeScrollSize) {
            inputDir.x = -1f;
        }

        if (Input.GetKey(KeyCode.D) || Input.mousePosition.x > Screen.width - edgeScrollSize) {
            inputDir.x = +1f;
        }


        if (Input.GetMouseButtonDown(1)) {
            dragPanMoveActive = true;
            lastMousePosition = Input.mousePosition;
        }
        if (Input.GetMouseButtonUp(1)) {
            dragPanMoveActive = false;
        }

        if (dragPanMoveActive) {
            Vector2 mouseMovementDelta = (Vector2)Input.mousePosition - lastMousePosition;

            inputDir.x = mouseMovementDelta.x * dragPanSpeed;
            inputDir.z = mouseMovementDelta.y * dragPanSpeed;

            lastMousePosition = Input.mousePosition;
        }


        Vector3 moveDir = transform.forward * inputDir.z + transform.right * inputDir.x;

        transform.position += moveSpeed * Time.deltaTime * moveDir;
    }

    IEnumerator IncreaseSpeed()
    {
        yield return new WaitForSeconds(.5f);

        if (increaseSpeed){
            
            moveSpeed += 100;
        }

        StartCoroutine(IncreaseSpeed());

    }


    void RotateCamera() {
        float rotateDir = 0f;

        if (Input.GetKey(KeyCode.E)) rotateDir = +1f;
        if (Input.GetKey(KeyCode.Q)) rotateDir = -1f;

        transform.eulerAngles += new Vector3(0, rotateDir * rotateSpeed * Time.deltaTime, 0);
    }
}
