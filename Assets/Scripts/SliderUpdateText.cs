using UnityEngine;
using UnityEngine.UIElements;

public class SliderUpdateText : UpdateText
{
    [SerializeField] private string textTemplate = "Number of planets: ";
    [SerializeField] private string targetSliderId = "NumberOfPlanetsSlider";
    VisualElement root;
    SliderInt slider;

    private void OnEnable() {
        root = GetComponent<UIDocument>().rootVisualElement;   
        slider = root.Q<SliderInt>(targetSliderId);
    }

    public void Update() {
        Debug.Log(textTemplate + slider.value.ToString());
        slider.label = textTemplate + slider.value.ToString();
    }
}
