using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogisticsNodeController : MonoBehaviour
{
    [SerializeField] private int id;
    [SerializeField] private int resource = 1;
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
            otherNode.resource += resource;
            resource = 0;
        }
    }

    private void Update() {
        if (resource > 0) {
            resourceHud.SetActive(true);
        }
        else { 
            resourceHud.SetActive(false);
        }
    }

    public int GetResource() {
        return resource;
    }

    public void SetResource(int newResource) {
        resource = newResource;
    }

    IEnumerator SpawnResources() {
        while (GenerateResources) {
            yield return new WaitForSeconds(2);

            resource += 1;
        }
    }
}
