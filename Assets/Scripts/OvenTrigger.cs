using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OvenTrigger : MonoBehaviour
{
    public OvenDoor ovenDoor;

    public bool openTrigger;
    public bool closeTrigger;

    public void OnTriggerEnter(Collider other)
    {
        if(openTrigger && other.gameObject.layer == 11)
        {
            ovenDoor.birthdayBoy = other.gameObject;
            ovenDoor.anim.Play("Open");
        }

        if(closeTrigger)
        {
            if(other.gameObject == ovenDoor.birthdayBoy)
            {
                ovenDoor.anim.Play("Close");
                ovenDoor.birthdayBoy = null;
            }
        }
    }
}
