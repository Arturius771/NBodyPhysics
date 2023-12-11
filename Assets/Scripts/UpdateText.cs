using UnityEngine;
using UnityEngine.UIElements;

public class UpdateText<T> : MonoBehaviour where T : TextElement {
    public void UpdateTextElement(TextElement element, string updatedText) {
        element.text = updatedText;
    }
}
