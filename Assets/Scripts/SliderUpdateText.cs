using UnityEngine;
using UnityEngine.UIElements;

public class SliderUpdateText : UpdateText<Label> {
    [SerializeField] private string textTemplate = "Number of planets: ";
    [SerializeField] private string targetSliderId = "NumberOfPlanetsSlider";
    VisualElement root;
    SliderInt slider;

    private void OnEnable() {
        root = GetComponent<UIDocument>().rootVisualElement;
        slider = root.Q<SliderInt>(targetSliderId);

        slider.RegisterCallback<ChangeEvent<int>>(OnSliderValueChanged);
    }

    private void OnSliderValueChanged(ChangeEvent<int> valueChangeEvent) {
        Label labelElement = slider.labelElement;
        UpdateTextElement(labelElement, textTemplate + slider.value.ToString());
    }
}
