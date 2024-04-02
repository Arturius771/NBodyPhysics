using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.XR;

public class EnergyCollector : MonoBehaviour
{
    [SerializeField] double energy = 0;
    [SerializeField] GameObject targetStar;
    [SerializeField] GameObject targetFactory;
    [SerializeField] double distance = 0;
    [SerializeField] double energyCollectionRatePerSecond = 0;

    private void Start() {
        targetStar = GameObject.Find("Star");
        targetFactory = GameObject.Find("Factory");
        StartCoroutine(CalculateEnergyDifference());
    }

    // Update is called once per frame
    void FixedUpdate() {
        distance = Vector3.Distance(this.gameObject.transform.position, targetStar.transform.position);

        
        energy += 10 / (Math.Pow(distance, 2) * (Math.PI * 4));
    }

    private IEnumerator CalculateEnergyDifference() {
        double startEnergy = energy;
        yield return new WaitForSeconds(1);
        energyCollectionRatePerSecond = energy - startEnergy;
        targetFactory.GetComponent<FactoryController>().energyResource += energyCollectionRatePerSecond;
        StartCoroutine(CalculateEnergyDifference());
    }
}
