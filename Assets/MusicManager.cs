using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour
{
    public AudioClip[] songs;
    AudioSource music;

    bool lastInverted;
    float musicTime;
    private void Awake()
    {
        if(GameManager.musicManager == null && GameManager.musicManager != this)
        {
            GameManager.musicManager = this;
            DontDestroyOnLoad(transform.gameObject);
        }

        else
        {
            Destroy(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        lastInverted = !GameManager.inverted;
        music = GetComponent<AudioSource>();
        music.clip = songs[0];
        music.Play();
    }

    private void Update()
    {
        if (SceneManager.GetActiveScene().name == "YorickBlockOutFinal")
        {
            musicTime = music.time;

            if (lastInverted != GameManager.inverted)
            {
                if(!GameManager.inverted)
                {
                    music.clip = songs[1];
                }

                else
                {
                    music.clip = songs[2];
                }

                music.time = musicTime;
                music.Play();
                lastInverted = GameManager.inverted;
            }
        }

    }
}
