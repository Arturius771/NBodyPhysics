
using UnityEngine;
using UnityEngine.UIElements;

public class FactoryController : MonoBehaviour
{
    [SerializeField] private GameObject uiDocument;
    [SerializeField] private LogisticsNodeController logisticsNode;
    [SerializeField] private GameObject prefab;
    [SerializeField] private GameObject resourceHud;
    [SerializeField] private int resource = 10;
    VisualElement root;
    Button spawnSpaceshipButton;
    Label resourceLabel;

    // Start is called before the first frame update
    void Start()
    {
        root = uiDocument.GetComponent<UIDocument>().rootVisualElement;
        spawnSpaceshipButton = root.Q<Button>("SpawnSpaceshipButton");
        resourceLabel = root.Q<Label>("ResourceValueLabel");
        spawnSpaceshipButton.clickable.clicked += OnSpawnSpaceshipButtonClicked;
    }

    private void FixedUpdate() {
        SetUIText();
        resource += logisticsNode.GetResource();
        logisticsNode.SetResource(0);
        ShowResourceHud();
    }


    private void ShowResourceHud() {
        if (resource > 0) {
            resourceHud.SetActive(true);
        }
        else {
            resourceHud.SetActive(false);
        }
    }

    private void OnSpawnSpaceshipButtonClicked() {
        if(resource >= 1) {
            resource -= 1;
            Instantiate(prefab, GetComponent<Transform>().position, Quaternion.identity);
        }        
    }

    private void SetUIText() {
        if (resource <= 0) {
            resourceLabel.text = "No more resources!";
        }
        else {
            resourceLabel.text = resource.ToString();
        }
    }
}
