
using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

public class FactoryController : MonoBehaviour
{
    [SerializeField] private GameObject uiDocument;
    [SerializeField] private LogisticsNodeController logisticsNode;
    [SerializeField] private GameObject spawnLocation;
    [SerializeField] private GameObject resourceHud;
    [SerializeField] private int resources = 10;
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
        resources += logisticsNode.GetResource();
        SetUIResourcesAvailableText();
        logisticsNode.SetResource(0);
        ShowResourceHud();
    }


    private void ShowResourceHud() {
        if (resources > 0) {
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
        if (resources <= 0) {
            resourceLabel.text = "No more resources!";
        }
        else {
            resourceLabel.text = resources.ToString();
        }
    }


    private IEnumerator BuildStrikeCraft() {
        if(resources >= strategy.GetResourceCost()) {
            resources -= strategy.GetResourceCost();
            SetUIResourcesAvailableText();
            yield return new WaitForSeconds(strategy.GetBuildTime());
            strategy.Build(spawnLocation.transform);
        }
    }
}
