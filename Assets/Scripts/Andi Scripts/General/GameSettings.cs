using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class GameSettings : MonoBehaviour
{
    public AudioMixer audioMixer;
    public Dropdown resolutionDropdown;
    public Dropdown qualityDropdown;
    public Dropdown textureDropdown;
    public Dropdown aaDropdown;
    public Slider volumeSlider;
    float currentVolume;
    Resolution[] resolutions;

    private void Start()
    {
        resolutionDropdown.ClearOptions();
        List<string> options = new List<string>();
        resolutions = Screen.resolutions;
        int currentResolutionIndex = 0;
        
        
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height + "" + resolutions[i].refreshRate + "Hz";
            options.Add(option);
            if (resolutions[i].width == Screen.currentResolution.width && 
                resolutions[i].height == Screen.currentResolution.height)
                currentResolutionIndex = i;
        }
        
        resolutionDropdown.AddOptions(options);
        resolutionDropdown.RefreshShownValue();
        LoadSettings(currentResolutionIndex);
    }

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("Volume", volume);
        currentVolume = volume;
    }

    public void SetFullScreen(bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;
    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    public void SetTextureQuality(int textureIndex)
    {
        QualitySettings.masterTextureLimit = textureIndex;
        qualityDropdown.value = 6;
    }

    public void SetAntiAliasing(int aaIndex)
    {
        QualitySettings.antiAliasing = aaIndex;
        qualityDropdown.value = 6;
    }

    public void SetQuality(int qualityIndex)
    {
        if (qualityIndex != 6) // if the user is not using any
        {
            QualitySettings.SetQualityLevel(qualityIndex);
        }

        switch (qualityIndex)
        {
            case 0: // quality level - very low
                textureDropdown.value = 3;
                aaDropdown.value = 0;
                break;
            case 1: // quality level - low
                textureDropdown.value = 2;
                aaDropdown.value = 0;
                break;
            case 2: // quality level - medium
                textureDropdown.value = 1;
                aaDropdown.value = 0;
                break;
            case 3: // quality level - high
                textureDropdown.value = 0;
                aaDropdown.value = 0;
                break;
            case 4: // quality level - very high
                textureDropdown.value = 0;
                aaDropdown.value = 1;
                break;
            case 5: // quality level - ultra
                textureDropdown.value = 0;
                aaDropdown.value = 2;
                break;
        }

        qualityDropdown.value = qualityIndex;
    }
    
    // Save some settings
    public void SaveSettings()
    {
        PlayerPrefs.SetInt("QualitySettingPreference",
            qualityDropdown.value);
        PlayerPrefs.SetInt("ResolutionPreference",
            resolutionDropdown.value);
        PlayerPrefs.SetInt("TextureQualityPreference",
            textureDropdown.value);
        PlayerPrefs.SetInt("AntiAliasingPreference",
            aaDropdown.value);
        PlayerPrefs.SetInt("FullscreenPreference",
            Convert.ToInt32(Screen.fullScreen));
        PlayerPrefs.SetFloat("VolumePreference",
            currentVolume);
    }
    
    // Settings Load from preferences
    public void LoadSettings(int currentResolutionIndex)
    {
        qualityDropdown.value = PlayerPrefs.HasKey("QualitySettingPreference") ? PlayerPrefs.GetInt("QualitySettingPreference") : 3;

        resolutionDropdown.value = PlayerPrefs.HasKey("ResolutionPreference") ? PlayerPrefs.GetInt("ResolutionPreference") : currentResolutionIndex;

        textureDropdown.value = PlayerPrefs.HasKey("TextureQualityPreference") ? PlayerPrefs.GetInt("TextureQualityPreference") : 0;

        aaDropdown.value = PlayerPrefs.HasKey("AntiAliasingPreference") ? PlayerPrefs.GetInt("AntiAliasingPreference") : 1;

        Screen.fullScreen = !PlayerPrefs.HasKey("FullscreenPreference") || Convert.ToBoolean(PlayerPrefs.GetInt("FullscreenPreference"));
        
        volumeSlider.value = PlayerPrefs.HasKey("VolumePreference") ? PlayerPrefs.GetFloat("VolumePreference") : PlayerPrefs.GetFloat("VolumePreference");
    }
}