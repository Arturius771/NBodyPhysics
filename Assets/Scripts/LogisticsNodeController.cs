using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogisticsNodeController : MonoBehaviour
{
    [SerializeField] private int id;
    [SerializeField] private int metalResource = 1;
    [SerializeField] private GameObject targetHome;
    [SerializeField] private GameObject resourceHud;
    [SerializeField] private bool GenerateResources = true;

    // Start is called before the first frame update
    void Start()
    {
        float distance = Vector3.Distance(gameObject.transform.position, targetHome.transform.position);
        if(id == 0) {
            id = (int)distance;
        }

        StartCoroutine(SpawnResources());
    }

    private void OnTriggerEnter(Collider other) {
        if (other == null) return;
        LogisticsNodeController otherNode = other.GetComponent<LogisticsNodeController>();

        if (otherNode.id < id) {
            otherNode.metalResource += metalResource;
            metalResource = 0;
        }
    }

    private void Update() {
        if (metalResource > 0) {
            resourceHud.SetActive(true);
        }
        else { 
            resourceHud.SetActive(false);
        }
    }

    public int GetMetalResource() {
        return metalResource;
    }

    public void SetMetalResource(int newResource) {
        metalResource = newResource;
    }

    IEnumerator SpawnResources() {
        while (GenerateResources) {
            yield return new WaitForSeconds(2);

            metalResource += 1;
        }
    }
}
