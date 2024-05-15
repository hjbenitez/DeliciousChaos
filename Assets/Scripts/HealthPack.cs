using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPack : MonoBehaviour
{
    AudioSource pickUpSFX;
    public GameObject inverted;
    public GameObject normal;

    bool pickedUp;
    // Start is called before the first frame update
    void Start()
    {
        pickUpSFX = GetComponent<AudioSource>();
        pickUpSFX.volume = GameManager.SetSFXVolume(pickUpSFX.volume);

        inverted.SetActive(false);
        normal.SetActive(true);

        pickedUp = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!pickedUp)
        {
            if (GameManager.inverted )
            {
                inverted.SetActive(true);
                normal.SetActive(false);
            }
            else
            {
                inverted.SetActive(false);
                normal.SetActive(true);
            }
        }

        if (pickedUp && !pickUpSFX.isPlaying)
        {
            GameObject.Find("HealthPackSpawner").GetComponent<HealthPackSpawner>().RespawnHealthPack();
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player" && !pickedUp)
        {
            PlayerMovement player = other.gameObject.GetComponent<PlayerMovement>();
            player.health = player.maxHealth;

            foreach(Transform child in transform)
            {
                child.gameObject.SetActive(false);
            }

            pickUpSFX.Play();
            pickedUp = true;
        }
    }
}
