using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Splat : MonoBehaviour
{
    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.volume = GameManager.SetSFXVolume(0.5f);
    }

    public void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.layer == 13)
        {
            audioSource.Play();
            Destroy(this);
        }
    }

}
