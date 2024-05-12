using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OvenOpening : MonoBehaviour
{
    public float openTime;
    public float closeTime;

    public Animator anim;
    
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("OpenOven", openTime, openTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenOven()
    {
        anim.SetTrigger("Open");

        Invoke("CloseOven", closeTime);
    }

    public void CloseOven()
    {
        anim.SetTrigger("Close");
    }
}
