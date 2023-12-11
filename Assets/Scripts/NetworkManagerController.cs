using System;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.UIElements;

public class NetworkManagerController : MonoBehaviour {
    [SerializeField] private GameObject uiDocument;
    VisualElement root;
    Button startHostButton;
    Button startClientButton;
    NetworkManager networkManager;

    // Start is called before the first frame update
    void OnEnable() {
        root = uiDocument.GetComponent<UIDocument>().rootVisualElement;
        startHostButton = root.Q<Button>("StartHostButton");
        startClientButton = root.Q<Button>("StartClientButton");
        networkManager = this.gameObject.GetComponent<NetworkManager>();

        startHostButton.clickable.clicked += OnStartHostButtonClick;
        startClientButton.clickable.clicked += OnStartClientButtonClick;
    }

    private void OnStartHostButtonClick() {
        if(startHostButton.text == "Start Host") {
            networkManager.StartHost();
            startHostButton.text = "Stop Host";
        }
        else {
            networkManager.Shutdown();
            startHostButton.text = "Start Host";
        }
    }

    private void OnStartClientButtonClick() {
        if (startHostButton.text == "Start Client") {
            networkManager.StartClient();
            startHostButton.text = "Stop Client";
        }
        else {
            networkManager.Shutdown();
            startHostButton.text = "Start Client";
        }
    }
}
