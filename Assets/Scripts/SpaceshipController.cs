using Unity.Burst.CompilerServices;
using UnityEngine;
using UnityEngine.AI;

public class SpaceshipController : MonoBehaviour
{

    public Camera camera;
    public NavMeshAgent agent;

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetMouseButtonDown(0)) {
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);
            Debug.DrawRay(ray.origin, ray.direction * 10000000, Color.green, 5f); // only draws once. Re-clicking does nothing

            if (Physics.Raycast(ray, out RaycastHit hit)) {
                Debug.Log("hit");
                agent.SetDestination(hit.point);
            }
        }
    }
}