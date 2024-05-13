using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPack : MonoBehaviour
{
    public GameObject inverted;
    public GameObject normal;
    
    // Start is called before the first frame update
    void Start()
    {
        inverted.SetActive(false);
        normal.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.inverted)
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

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            other.gameObject.GetComponent<PlayerMovement>().health = other.gameObject.GetComponent<PlayerMovement>().maxHealth;
            GameObject.Find("HealthPackSpawner").GetComponent<HealthPackSpawner>().RespawnHealthPack();
            Destroy(this.gameObject);
        }
    }
}
