using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using TMPro;

public class SettingsMenu : MonoBehaviour
{
    public AudioMixer mainMixer;
    public TMP_Dropdown resolutionDropdown;

    private Resolution[] resolutions;

    private void Start() {
        resolutions = Screen.resolutions;
        resolutionDropdown.ClearOptions();
        List<string> options = new List<string>();

        int currentResolutionIndex = 0;
        for (int i = 0; i < resolutions.Length; i++) {
            string option = resolutions[i].width + "x" + resolutions[i].height;
            options.Add(option);

            if ((resolutions[i].width == Screen.currentResolution.width ) && (resolutions[i].height == Screen.currentResolution.height)) {
                currentResolutionIndex = i;
            }
        }

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
    }

    public void setVolume(float volume) {
        mainMixer.SetFloat("MainVolume", volume);
    }

    public void setVolumeMusic(float volume) {
        mainMixer.SetFloat("MusicVolume", volume);
    }

    public void setVolumeSFX(float volume) {
        mainMixer.SetFloat("SFXVolume", volume);
    }

    public void setFullScreen(bool isFullScreen) {
        Screen.fullScreen = isFullScreen;
    }

    public void setResolution(int resolutionIndex) {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }
}
