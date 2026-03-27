using UnityEngine;
using UnityEngine.UIElements;

public class RuntimeUI : MonoBehaviour
{
    Toggle _fullScreen;
    EnumField _quality;
    DropdownField _resolution;
    Button _applyGraphicsChanges;

    //Add logic that interacts with the UI controls in the `OnEnable` methods
    private void OnEnable()
    {
        var uiDocument = GetComponent<UIDocument>();

        
        _fullScreen = uiDocument.rootVisualElement.Q("fullScreen") as Toggle;
        _quality = uiDocument.rootVisualElement.Q("quality") as EnumField;
        _resolution = uiDocument.rootVisualElement.Q("resolution") as DropdownField;

        
        _applyGraphicsChanges  = uiDocument.rootVisualElement.Q("applyGraphicsChanges") as Button;
        _applyGraphicsChanges.RegisterCallback<ClickEvent>(ApplyGraphicsChanges);

        var sfx = uiDocument.rootVisualElement.Q("sfx");
        sfx.RegisterCallback<ChangeEvent<float>>((ChangeEvent<float> evt) => Debug.Log($"SFX: {evt.newValue}"));

        var music = uiDocument.rootVisualElement.Q("music");
        music.RegisterCallback<ChangeEvent<float>>((ChangeEvent<float> evt) => Debug.Log($"Music: {evt.newValue}"));
    }

    private void OnDisable()
    {
        _applyGraphicsChanges.UnregisterCallback<ClickEvent>(ApplyGraphicsChanges);
    }

    private void ApplyGraphicsChanges(ClickEvent evt)
    {
        Debug.Log($"Update graphics with: {_quality.value} {_resolution.value} {(_fullScreen.value ? "Fullscreen" : "Windowed")}");
    }
}