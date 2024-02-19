using System;
using System.Collections;
using UnityEngine;

public class EnergyCollector : MonoBehaviour
{
    [SerializeField] double energy = 0;
    [SerializeField] GameObject targetStar;
    [SerializeField] double distance = 0;
    [SerializeField] double energyCollectionRatePerSecond = 0;

    private void Start() {
        StartCoroutine(CalculateEnergyDifference());
    }

    // Update is called once per frame
    void Update() {
        distance = Vector3.Distance(this.gameObject.transform.position, targetStar.transform.position);

        energy += 1 / (Math.Pow(distance, 2) * (Math.PI * 4));
    }

    private IEnumerator CalculateEnergyDifference() {
        double startEnergy = energy;
        yield return new WaitForSeconds(1);
        energyCollectionRatePerSecond = energy - startEnergy;
        StartCoroutine(CalculateEnergyDifference());
    }
}
