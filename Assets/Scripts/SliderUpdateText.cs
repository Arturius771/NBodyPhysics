using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SliderUpdateText : UpdateText
{
    [SerializeField] private TextMeshProUGUI targetText;
    [SerializeField] private Slider updatedText;
    [SerializeField] private string textTemplate = "Number of planets: ";

    public void ChangeText() {
        updatedText = this.gameObject.GetComponent<Slider>();
        UpdateUIText(targetText, $"{textTemplate}{updatedText.value}");
    }
}
