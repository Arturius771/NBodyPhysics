
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

public class FactoryController : MonoBehaviour
{
    [SerializeField] private GameObject uiDocument;
    [SerializeField] private LogisticsNodeController logisticsNode;
    [SerializeField] private GameObject spawnLocation;
    [SerializeField] private GameObject resourceHud;
    [SerializeField] private int metalResource = 10;
    public double energyResource = 0;
    [SerializeField] private BuildStrategy shipStrategy;
    [SerializeField] private BuildStrategy energyCollectorStrategy;
    VisualElement root;
    Button spawnSpaceshipButton;
    Button spawnEnergyCollectorButton;
    Label metalResourceLabel;
    Label energyResourceLabel;

    // Start is called before the first frame update
    void Start()
    {
        root = uiDocument.GetComponent<UIDocument>().rootVisualElement;
        spawnSpaceshipButton = root.Q<Button>("SpawnSpaceshipButton");
        spawnEnergyCollectorButton = root.Q<Button>("SpawnEnergyCollectorButton");
        metalResourceLabel = root.Q<Label>("MetalValueLabel");
        energyResourceLabel = root.Q<Label>("EnergyValueLabel");

        SetUIResourcesAvailableText();


        spawnSpaceshipButton.clickable.clicked += OnSpawnSpaceshipButtonClicked;
        spawnEnergyCollectorButton.clickable.clicked += OnSpawnEnergyCollectorButtonClicked;
    }
     
    private void FixedUpdate() {
        if(logisticsNode != null) { 
            metalResource += logisticsNode.GetMetalResource(); 
        }
        SetUIResourcesAvailableText();
        logisticsNode.SetMetalResource(0);
        ShowResourceHud();
    }


    private void ShowResourceHud() {
        if (metalResource > 0) {
            resourceHud.SetActive(true);
        }
        else {
            resourceHud.SetActive(false);
        }
    }

    private void OnSpawnSpaceshipButtonClicked() {
        StartCoroutine(BuildStrikeCraft());
    }

    private void OnSpawnEnergyCollectorButtonClicked() {
        StartCoroutine(BuildEnergyCollector());
    }

    private void SetUIResourcesAvailableText() {
        if (metalResource <= 0) {
            metalResourceLabel.text = "No more metal!";
        }
        else {
            metalResourceLabel.text = metalResource.ToString();
        }
        if (energyResource <= 0) {
            energyResourceLabel.text = "No more energy!";
        }
        else {
            energyResourceLabel.text = energyResource.ToString();
        }
    }


    private IEnumerator BuildStrikeCraft() {
        if(metalResource >= shipStrategy.GetMetalResourceCost() && energyResource >= shipStrategy.GetEnergyResourceDrainRate() * shipStrategy.GetBuildTime()) {
            metalResource -= shipStrategy.GetMetalResourceCost();
            SetUIResourcesAvailableText();
            StartCoroutine(DrainEnergy(shipStrategy.GetEnergyResourceDrainRate(), shipStrategy.GetBuildTime()));
            yield return new WaitForSeconds(shipStrategy.GetBuildTime());
            shipStrategy.Build(spawnLocation.transform);
        }
        else {
            Debug.Log("Not enough resources!");
        }
    }

    private IEnumerator BuildEnergyCollector() {
        if (metalResource >= energyCollectorStrategy.GetMetalResourceCost() && energyResource >= energyCollectorStrategy.GetEnergyResourceDrainRate() * shipStrategy.GetBuildTime()) {
            metalResource -= energyCollectorStrategy.GetMetalResourceCost();
            SetUIResourcesAvailableText();
            StartCoroutine(DrainEnergy(energyCollectorStrategy.GetEnergyResourceDrainRate(), energyCollectorStrategy.GetBuildTime()));
            yield return new WaitForSeconds(energyCollectorStrategy.GetBuildTime());
            energyCollectorStrategy.Build(spawnLocation.transform);
        }
        else {
            Debug.Log("Not enough resources!");
        }
    }

    private IEnumerator DrainEnergy(int drainRate, int buildTime) {
        for (int i = 0; i <= buildTime; i++) {
            yield return new WaitForSeconds(1);
            energyResource -= drainRate;
        }
    }
}
