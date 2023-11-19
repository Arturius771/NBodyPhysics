using TMPro;
using UnityEngine.UI;

public class SliderUpdateText : UpdateText
{
    public TextMeshProUGUI targetText;
    Slider updatedText;

    public void ChangeText() {
        updatedText = this.gameObject.GetComponent<Slider>();
        UpdateUIText(targetText, $"Number of planets: {updatedText.value}");
    }
}
