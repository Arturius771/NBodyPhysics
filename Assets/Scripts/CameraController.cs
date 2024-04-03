using System.Collections;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class CameraController : MonoBehaviour {
    // TODO: Create base camera class and inherit
    public float moveSpeed = 20f;
    [SerializeField] private float rotationSpeed = 0.1f;
    [SerializeField] private float zoomSpeed = 5f;
    private bool increaseSpeed = false;
    void Update() {
        RotateCamera();
        ZoomCamera();
        CameraMovement();
    }
    void Start()
    {
        StartCoroutine(IncreaseSpeed());
    }
        void CameraMovement() {
        //TODO: Implement drag camera movement
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 moveDirection = new Vector3(horizontalInput, 0, verticalInput).normalized;
        float edgeSize = 30f;
        if (moveDirection != Vector3.zero) {
            // Adjust the camera position based on the WASD input
            transform.Translate(moveDirection * moveSpeed * Time.deltaTime, Space.World);
            increaseSpeed = true;
        }
        
        else if (Input.mousePosition.x > Screen.width - edgeSize) // Right 
        {
            Debug.Log(moveSpeed);
            transform.Translate(new Vector3(1, 0, 0) * moveSpeed * Time.deltaTime, Space.World);
            increaseSpeed = true;
        }
        else if (Input.mousePosition.y < edgeSize) // Down
        {
            Debug.Log(Screen.width);
            transform.Translate(new Vector3(0, 0, -1) * moveSpeed * Time.deltaTime, Space.World);
            increaseSpeed = true;
        }
        else if (Input.mousePosition.x < edgeSize) // Left
        {
            Debug.Log(Screen.width);
            transform.Translate(new Vector3(-1, 0, 0) * moveSpeed * Time.deltaTime, Space.World);
            increaseSpeed = true;
        }
        else if (Input.mousePosition.y > Screen.height - edgeSize) // UP
        {
            Debug.Log(Screen.width);
            transform.Translate(new Vector3(0, 0, 1) * moveSpeed * Time.deltaTime, Space.World);
            increaseSpeed = true;
        }
        else {
            increaseSpeed = false;
            moveSpeed = 20f;
        }
    }
    IEnumerator IncreaseSpeed()
    {
        yield return new WaitForSeconds(.5f);
        if (increaseSpeed)
        {
            
            moveSpeed = moveSpeed + 100;
            Debug.Log("Test");
        }
        StartCoroutine(IncreaseSpeed());

    }

    void ZoomCamera()
        // TODO: Implement actual zoom
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
