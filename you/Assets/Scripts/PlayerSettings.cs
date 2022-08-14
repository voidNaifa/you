using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class PlayerSettings : MonoBehaviour
{   
    [SerializeField] private Slider volumeMaster;
    [SerializeField] private TMP_Dropdown qualityDropdown;
    [SerializeField] private TMP_Dropdown resolutionDropdown;
    public void SavePrefs(string prefs)
    {
        if(prefs == "Audio")
        {
            PlayerPrefs.SetFloat("volumeMaster", volumeMaster.value);
        }
        else if( prefs == "Graphics")
        {
            PlayerPrefs.SetInt("quality", qualityDropdown.value);
            PlayerPrefs.SetInt("resolution", resolutionDropdown.value);
        }
        else if(prefs == "Language")
        {
            //PlayerPrefs.SetString("language", )
        }

    
    
    }

    public void LoadPrefs()
    {
        
    }
    /*
    [Header("General Settings")]
    [SerializeField] private bool canUse = false;
    [SerializeField] private Menu menuController;


    [Header("Volume Settings")]
    [SerializeField] private TMP_Text volumeValue = null;
    [SerializeField] private Slider volumeSlider = null;
    [Header("Brightness Settings")]
    [SerializeField] private Slider brightnessSlider = null;
    [SerializeField] private TMP_Text brightnessValue = null;    

    [Header("Quality Settings")]
    [SerializeField] private TMP_Dropdown qualityDropdown;

    [Header("FullScreen Settings")]
    [SerializeField] private Toggle fullScreenToggle;    

    private void  Awake()
    {
        if(canUse)
        {
            if(PlayerPrefs.HasKey("masterVolume"))
            {
                float localVolume = PlayerPrefs.GetFloat("masterVolume");

                volumeValue.text = localVolume.ToString("0");
                volumeSlider.value = localVolume;
                AudioListener.volume = localVolume;
            }
            else 
            {
                menuController.ResetButton("Audio");
            }

            if(PlayerPrefs.HasKey("masterQuality"))
            {
                int localQuality = PlayerPrefs.GetInt("masterQuality");
                qualityDropdown.value = localQuality;
                QualitySettings.SetQualityLevel(localQuality);
            }

            if(PlayerPrefs.HasKey("masterFullScreen"))
            {
                int localFullScreen = PlayerPrefs.GetInt("masterFullScreen");
                if(localFullScreen == 1)
                {
                    Screen.fullScreen = true;
                    fullScreenToggle.isOn = true;
                }
                else
                {
                    Screen.fullScreen = false;
                    fullScreenToggle.isOn = false;
                }
            }
            if(PlayerPrefs.HasKey("masterBrightness"))
            {
                float localBrightness = PlayerPrefs.GetFloat("masterBrightness");

                brightnessValue.text = localBrightness.ToString("0");
                brightnessSlider.value = localBrightness;
            }
        }
    }
    */

}
