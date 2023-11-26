using Unity.Burst.CompilerServices;
using UnityEngine;
using UnityEngine.AI;

public class SpaceshipController : MonoBehaviour
{

    private Camera camera;
    private NavMeshAgent agent;
    [SerializeField] private LayerMask clickLayer;

    private void Start() {
        camera = Camera.main;
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {        
        if (Input.GetMouseButtonDown(MouseButton.right)) {
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);
            Debug.DrawRay(ray.origin, ray.direction * 10000000, Color.green, 5f); 

            if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, clickLayer)) {
                agent.SetDestination(hit.point);
            }
        }
    }
}