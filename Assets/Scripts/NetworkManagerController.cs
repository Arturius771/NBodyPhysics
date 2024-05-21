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

    bool networkHostStarted = false;
    bool networkClientStart = false;

    // TODO - review for improvements and bugs

    // Start is called before the first frame update
    void OnEnable() {
        root = uiDocument.GetComponent<UIDocument>().rootVisualElement;
        quitToMenuButton = root.Q<Button>("QuitToMenuButton");
        startHostButton = root.Q<Button>("StartHostButton");
        startClientButton = root.Q<Button>("StartClientButton");
        networkManager = this.gameObject.GetComponent<NetworkManager>();


        startHostButton.clickable.clicked += OnStartHostButtonClick;
        quitToMenuButton.clickable.clicked += OnQuitToMenuButtonClick;
        startClientButton.clickable.clicked += OnStartClientButtonClick;
    }

    private void OnStartHostButtonClick() {
        if (networkHostStarted) {
            networkManager.Shutdown();
            startHostButton.text = "Start Host";
        }
        else {
            networkManager.StartHost();
            startHostButton.text = "Stop Host";
        }
        networkHostStarted = !networkHostStarted;
    }

    private void OnQuitToMenuButtonClick() {
        SceneManager.LoadScene("4PlaytestMenu");
    }

    private void OnStartClientButtonClick() {
        if (networkClientStart) {
            networkManager.Shutdown();
            startClientButton.text = "Start Client";
        }
        else {
            networkManager.StartClient();
            startClientButton.text = "Stop Client";
        }
        networkClientStart = !networkClientStart;
    }
}
