using System;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class NetworkManagerController : MonoBehaviour {
    [SerializeField] private GameObject uiDocument;
    VisualElement root;
    Button startHostButton;
    Button startClientButton;
    Button quitToMenuButton;
    NetworkManager networkManager;

    // Start is called before the first frame update
    void OnEnable() {
        root = uiDocument.GetComponent<UIDocument>().rootVisualElement;
        startHostButton = root.Q<Button>("StartHostButton");
        quitToMenuButton = root.Q<Button>("QuitToMenuButton");
        startClientButton = root.Q<Button>("StartClientButton");
        networkManager = this.gameObject.GetComponent<NetworkManager>();

        startHostButton.clickable.clicked += OnStartHostButtonClick;
        quitToMenuButton.clickable.clicked += OnQuitToMenuButtonClick;
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

    private void OnQuitToMenuButtonClick() {
        SceneManager.LoadScene("4PlaytestMenu");
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
