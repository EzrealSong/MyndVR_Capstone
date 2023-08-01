using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameSetting : MonoBehaviour
{

    [Header("Volume Setting")]
    [SerializeField] private TMP_Text volumeTextValue = null;
    [SerializeField] private Slider volumeSlider = null;
    [SerializeField] private float defaultVolume = 0.5f;

    [Header("Graphics Settings")]
    [SerializeField] private Slider brightnessSlider = null;
    [SerializeField] private TMP_Text brightnessTextValue = null;
    [SerializeField] private float defaultBrightness = 1.0f;
    [SerializeField] private Light directionalLight;
    

public void SetVolume(float volume)
{
    AudioListener.volume = volume;
    volumeTextValue.text = volume.ToString("0.0");

}

private void VolumeApplay()
{
    PlayerPrefs.SetFloat("masterVolume", AudioListener.volume);
    //Show Prompt
   
}

// public void SetBrightness(float brightness)
// {
//     // Add a listener to the slider's value changed event
//     brightnessSlider.onValueChanged.AddListener(OnBrightnessSliderChanged);

//     // Load the saved brightness value (optional)
//     float savedBrightness = PlayerPrefs.GetFloat("GameBrightness", 1f);
//     brightnessSlider.value = savedBrightness;
//     OnBrightnessSliderChanged(savedBrightness);
//     directionalLight.intensity = brightness;
//     brightnessTextValue.text = brightness.ToString("0.0");

// }

public void ResetButton()
{
    //Volumn
    AudioListener.volume = defaultVolume;
    volumeSlider.value = defaultVolume;
    volumeTextValue.text = defaultVolume.ToString("0.0");
    VolumeApplay();

    //Graphics
    brightnessSlider.value = defaultBrightness;
    directionalLight.intensity = defaultBrightness;
    brightnessTextValue.text = defaultBrightness.ToString("0.0"); // Display the value with one decimal places
    PlayerPrefs.SetFloat("GameBrightness", defaultBrightness);
}


private void Start()
    {
        // Assuming your directional light is already set in the scene
        if (directionalLight == null)
        {
            Debug.LogWarning("Directional light is not set. Please assign the main light source to the 'directionalLight' variable in the inspector.");
        }

        // Add a listener to the slider's value changed event
        brightnessSlider.onValueChanged.AddListener(OnBrightnessSliderChanged);

        // Load the saved brightness value (optional)
        float savedBrightness = PlayerPrefs.GetFloat("GameBrightness", 1.0f);
        brightnessSlider.value = savedBrightness;
        OnBrightnessSliderChanged(savedBrightness);
        // Load the saved Volumn value (optional)
        float savedVolumn = PlayerPrefs.GetFloat("masterVolume", 1.0f);
        volumeSlider.value = savedVolumn;
        SetVolume(savedVolumn);
    }

    private void OnBrightnessSliderChanged(float brightnessValue)
    {
        // Ensure the directional light is assigned
        if (directionalLight == null)
            return;

        // Update the brightness of the directional light
        directionalLight.intensity = brightnessValue;

        // Update the TextMeshPro Text to display the intensity value
        brightnessTextValue.text = brightnessValue.ToString("0.0"); // Display the value with one decimal places

        // Save the brightness value (optional)
        PlayerPrefs.SetFloat("GameBrightness", brightnessValue);
    }

}
