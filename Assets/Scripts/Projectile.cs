using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;

public abstract class Projectile : MonoBehaviour 
{ 
    public abstract void fired();

    public abstract float GetFireRate();
    public abstract int GetDamage();

    public virtual void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer != 3 && other.gameObject.layer != 7)
        {
            Destroy(gameObject);
        }
    }
}
