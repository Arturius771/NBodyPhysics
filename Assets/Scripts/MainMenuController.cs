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
        SceneManager.LoadScene("5SpaceshipControl");
    }

    private void OnSendFeedbackButtonClick() {
        Application.OpenURL("https://docs.google.com/forms/d/1fFBFRc8WF5dCRHoOMPoxWIUaMGMCVrceE_lyHu3tRp0/edit");
    }

    private void OnQuitButtonClick() {
        Application.Quit();
    }
}
