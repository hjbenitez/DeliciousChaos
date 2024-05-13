using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OptionsMenuManager : MonoBehaviour
{
    public Slider mainVolumeSlider;
    public Slider sfxVolumeSlider;
    public Slider musicVolumeSlider;

    private void Start()
    {
        mainVolumeSlider.value = GameManager.mainVolume;
        sfxVolumeSlider.value = GameManager.sfxVolume;
        musicVolumeSlider.value = GameManager.musicVolume;
    }

    public void ClickReturnMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void mainVolumeChange()
    {
        GameManager.mainVolume = mainVolumeSlider.value;
        sfxVolumeChange();
        musicVolumeChange();
    }

    public void sfxVolumeChange()
    {
        GameManager.sfxVolume = sfxVolumeSlider.value;
    }

    public void musicVolumeChange()
    {
        GameManager.musicVolume = musicVolumeSlider.value;
        GameManager.ChangeMusicVolume();
    }

}
