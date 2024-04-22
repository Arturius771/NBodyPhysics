using UnityEngine;
using UnityEngine.AI;

public class SpaceshipController : MonoBehaviour
{
    private NavMeshAgent agent;
    private Vector3 targetPosition;
    [SerializeField] private int stopMovingRange = 50;
    [SerializeField] private LayerMask clickLayer;
    public bool selected = false;
    public bool canBeBulkSelected = false;

    private void Start() {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    private void Update()
    {        
        if (selected && Input.GetMouseButtonDown(MouseButton.right)) {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Debug.DrawRay(ray.origin, ray.direction * 10000000, Color.green, 5f); 

            if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, clickLayer)) {
                SetDestination(hit.point);
            }
        }

        if(Vector3.Distance(this.transform.position, targetPosition) < stopMovingRange) {
            agent.ResetPath();
        }
    }

    public void SetDestination(Vector3 targetPosition) {
        this.targetPosition = targetPosition;
        agent.SetDestination(targetPosition);
    }
}