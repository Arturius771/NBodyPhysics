
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
    [SerializeField] private int energyResource = 10;
    [SerializeField] private BuildStrategy strategy;
    VisualElement root;
    Button spawnSpaceshipButton;
    Label resourceLabel;

    // Start is called before the first frame update
    void Start()
    {
        root = uiDocument.GetComponent<UIDocument>().rootVisualElement;
        spawnSpaceshipButton = root.Q<Button>("SpawnSpaceshipButton");
        resourceLabel = root.Q<Label>("ResourceValueLabel");

        SetUIResourcesAvailableText();


        spawnSpaceshipButton.clickable.clicked += OnSpawnSpaceshipButtonClicked;
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

    private void SetUIResourcesAvailableText() {
        if (metalResource <= 0) {
            resourceLabel.text = "No more resources!";
        }
        else {
            resourceLabel.text = metalResource.ToString();
        }
    }


    private IEnumerator BuildStrikeCraft() {
        if(metalResource >= strategy.GetMetalResourceCost()) {
            metalResource -= strategy.GetMetalResourceCost();
            SetUIResourcesAvailableText();
            StartCoroutine(DrainEnergy());
            yield return new WaitForSeconds(strategy.GetBuildTime());
            strategy.Build(spawnLocation.transform);
        }
    }

    private IEnumerator DrainEnergy() {
        for (int i = 0; i <= strategy.GetBuildTime(); i++) {
            yield return new WaitForSeconds(1);
            energyResource -= strategy.GetEnergyResourceDrainRate();
        }
    }
}
