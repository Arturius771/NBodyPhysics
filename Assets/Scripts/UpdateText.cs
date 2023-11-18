using TMPro;
using UnityEngine;

public class UpdateText : MonoBehaviour
{
    public void UpdateUIText(TextMeshProUGUI targetText, string updatedText) {
        targetText.text = updatedText;
    }
}
