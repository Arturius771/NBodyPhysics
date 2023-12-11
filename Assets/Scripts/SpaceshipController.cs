using UnityEngine;
using UnityEngine.AI;

public class SpaceshipController : MonoBehaviour
{
    private NavMeshAgent agent;
    [SerializeField] private LayerMask clickLayer;

    private void Start() {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    private void Update()
    {        
        if (Input.GetMouseButtonDown(MouseButton.right)) {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Debug.DrawRay(ray.origin, ray.direction * 10000000, Color.green, 5f); 

            if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, clickLayer)) {
                SetDestination(hit.point);
            }
        }
    }

    public void SetDestination(Vector3 targetPosition) {
        agent.SetDestination(targetPosition);
    }
}