using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OptionsMenuManager : MonoBehaviour
{
    public Slider musicVolumeSlider;

    private void Start()
    {
        musicVolumeSlider.value = GameManager.musicVolume;
    }

    public void ClickReturnMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void musicVolumeChange()
    {
        GameManager.musicVolume = musicVolumeSlider.value;
        GameManager.ChangeMusicVolume();
    }
}
