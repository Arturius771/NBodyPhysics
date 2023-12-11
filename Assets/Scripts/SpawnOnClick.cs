using UnityEngine;

public class SpawnOnClick : MonoBehaviour
{

    [SerializeField] private LayerMask targetClickLayer;
    [SerializeField] private GameObject prefab;
    private Camera cam;


    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(MouseButton.right))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, targetClickLayer)) {
                Vector3 position = hit.point;
                Instantiate(prefab, position, Quaternion.identity);
            }
        }
    }
}
