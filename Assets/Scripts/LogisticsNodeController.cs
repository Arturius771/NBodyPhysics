using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogisticsNodeController : MonoBehaviour
{

    private int id;
    [SerializeField] private int resource = 1;
    [SerializeField] private GameObject targetHome; 

    // Start is called before the first frame update
    void Start()
    {
        float distance = Vector3.Distance(gameObject.transform.position, targetHome.transform.position);
        id = (int)distance;
    }

    private void OnTriggerEnter(Collider other) {
        LogisticsNodeController otherNode = other.GetComponent<LogisticsNodeController>();

        if (otherNode == null || other == null) return;

        if (otherNode.id < id) {
            otherNode.resource += resource;
            resource = 0;
        }
    }
}
