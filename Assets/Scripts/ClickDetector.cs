using UnityEngine;

public class ClickDetector : MonoBehaviour
{

    public LayerMask clickSurface;
    public GameObject prefab;
    public int clickRange = 500;
    Camera cam;


    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hit, clickRange, clickSurface)) {
                Vector3 position = hit.point;
                Instantiate(prefab, position, Quaternion.identity);
            }
        }
    }
}
