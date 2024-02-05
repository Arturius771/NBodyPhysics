using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class MainMenuController : MonoBehaviour
{
    [SerializeField] private GameObject uiDocument;
    VisualElement root;
    Button startButton;
    Button sendFeedbackButton;
    Button quitButton;

    // Start is called before the first frame update
    void OnEnable() {
        root = uiDocument.GetComponent<UIDocument>().rootVisualElement;
        startButton = root.Q<Button>("StartButton");
        sendFeedbackButton = root.Q<Button>("SendFeedbackButton");
        quitButton = root.Q<Button>("QuitButton");

        startButton.clickable.clicked += OnStartButtonClick;
        sendFeedbackButton.clickable.clicked += OnSendFeedbackButtonClick;
        quitButton.clickable.clicked += OnQuitButtonClick;
    }

    private void OnStartButtonClick() {
        Debug.Log("here");
        SceneManager.LoadScene("3Playtest");
    }

    private void OnSendFeedbackButtonClick() {
        Application.OpenURL("https://docs.google.com/forms/d/e/1FAIpQLSe3PzN0A9dBB7fAO4lulAxPAfdQtCIJ97-YnESCxEEFGEV-yg/viewform?usp=sf_link");
    }

    private void OnQuitButtonClick() {
        Application.Quit();
    }
}
