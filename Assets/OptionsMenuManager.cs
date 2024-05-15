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
    public AudioClip[] hitSoundClips;

    AudioSource audioSource;
    bool sfxChanged = false;

    private void Start()
    {
        mainVolumeSlider.value = GameManager.mainVolume;
        sfxVolumeSlider.value = GameManager.sfxVolume;
        musicVolumeSlider.value = GameManager.musicVolume;

        audioSource = gameObject.GetComponent<AudioSource>();   
    }

    private void Update()
    {
        if (sfxChanged && Input.GetMouseButtonUp(0))
        {
            int i  = Random.Range(0, hitSoundClips.Length);
            audioSource.clip = hitSoundClips[i];
            audioSource.Play();
            sfxChanged = false;
        }
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
        audioSource.volume = GameManager.SetSFXVolume(0.5f);
        sfxChanged = true;

    }

    public void musicVolumeChange()
    {
        GameManager.musicVolume = musicVolumeSlider.value;
        GameManager.ChangeMusicVolume();
    }
}
