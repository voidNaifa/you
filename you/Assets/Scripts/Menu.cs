using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Menu : MonoBehaviour
{
    [Header("Volume Settings")]
    [SerializeField] private TMP_Text volumeValue = null; 
    [SerializeField] private Slider volumeSlider = null;
    [SerializeField] private float defaultVolume  = 0f;
    [SerializeField] private AudioMixer audioMixer;
    [Header("Levels To Load")]
    public string _newGameLevel;
    private string levelToLoad;

    [Header("Resolution Dropdowns")]
    public TMP_Dropdown resolutionDropdown;
    private Resolution[] resolutions;

    [Header("Graphics Settings")]
    [SerializeField] private Slider brightnessSlider = null;
    [SerializeField] private TMP_Text brightnessValue = null;
    [SerializeField] private float defaultBrightness = 7;

    [Space(10)]
    [SerializeField] private TMP_Dropdown qualityDropdown;
    [SerializeField] private Toggle fullScreenToggle;
    
    public Animator animPlayer;
    int idle;    
    private void Start() 
    {   

        //animPlayer.Play("player_idle_down");

        Cursor.visible = true;        
        resolutions = Screen.resolutions;
        resolutionDropdown.ClearOptions();    

        List<string> options = new List<string>();

        int currentResolutionIndex = 0;

        for (int i = 0; i< resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);

            if(resolutions[i].width == Screen.width && resolutions[i].height == Screen.height)
            {
                currentResolutionIndex = i;
            }
        }

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();        
    }


    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }
    public void SetFullScreen (bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;
    }
    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("volume", volume);
        volumeValue.text = volume.ToString("0");
    }

        public void NewGameDialogYes()
    {
        Cursor.visible = false;        
        SceneManager.LoadScene(_newGameLevel);
    }

    public void QuitButton()
    {
        Application.Quit();
    }

    public void MenuAnim()
    {
        animPlayer.Play("player_idle_down_menu");
    }
    public void OptionsAnim()
    {
        animPlayer.Play("player_walk_down_menu");
    }
    public void GraphicsAnim()
    {
        animPlayer.Play("player_rotation_menu");
    }






























    /*

    //private int _qualityLevel;
    private bool _isFullScreen;
    private float _brightnessLevel;





    public Button loadButton;


    void Start()
    {

        resolutions = Screen.resolutions;
        resolutionDropdown.ClearOptions();    

        List<string> options = new List<string>();

        int currentResolutionIndex = 0;

        for (int i = 0; i< resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);

            if(resolutions[i].width == Screen.width && resolutions[i].height == Screen.height)
            {
                currentResolutionIndex = 1;
            }
        }

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();



        if(PlayerPrefs.HasKey("SavedLevel"))
        {

            loadButton.interactable = true;
        }
    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    public void NewGameDialogYes()
    {
        SceneManager.LoadScene(_newGameLevel);
    }

    public void LoadGameDialogYes()
    {
        if(PlayerPrefs.HasKey("SavedLevel"))
        {
            levelToLoad = PlayerPrefs.GetString("SavedLevel");
            SceneManager.LoadScene(levelToLoad);
        }
    }

    public void QuitButton()
    {
        Application.Quit();
    }


    public void SetVolume(float volume)
    {
        //AudioListener.volume = volume;
        audioMixer.SetFloat("volume", volume);
        volumeValue.text = volume.ToString("0");
    }

    public void VolumeApply()
    {
       PlayerPrefs.SetFloat("masterVolume", AudioListener.volume); 
    }
    public void ResetButton(string MenuType)
    {
        if (MenuType == "Audio")
        {
            AudioListener.volume = defaultVolume;
            volumeSlider.value = defaultVolume;
            volumeValue.text = defaultVolume.ToString("00");
            VolumeApply();
        }
        /*if (MenuType == "Graphics")
        {
            brightnessSlider.value = defaultBrightness;
            brightnessValue.text = defaultBrightness.ToString("0");

            qualityDropdown.value = 1;
            QualitySettings.SetQualityLevel(1);

            fullScreenToggle.isOn = true;
            Screen.fullScreen = true;

            Resolution currentResolution = Screen.currentResolution;
            Screen.SetResolution(currentResolution.width, currentResolution.height, Screen.fullScreen);
            resolutionDropdown.value = resolutions.Length;
            GraphicsApply();

        }
    }

    public void SetBrightness(float brightness)
    {
        _brightnessLevel = brightness;
        brightnessValue.text = brightness.ToString("0");
    }
    public void SetFullScreen(bool isFullScreen)
    {
        _isFullScreen = isFullScreen;
    }

    public void SetQuality(int qualityIndex)
    {
        //_qualityLevel = qualityIndex;
        QualitySettings.SetQualityLevel(qualityIndex);

    }

    /*public void GraphicsApply()
    {
        PlayerPrefs.SetFloat("masterBrightness", _brightnessLevel);
        PlayerPrefs.SetInt("masterQuality", +_qualityLevel);
        QualitySettings.SetQualityLevel(_qualityLevel);
        
        PlayerPrefs.SetInt("masterFullScreen", (_isFullScreen ? 1 : 0));
        Screen.fullScreen = _isFullScreen;

        //StartCoroutine(ConfirmationBox());

    }
    */

}




