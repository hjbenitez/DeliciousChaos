using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;

public abstract class Projectile : MonoBehaviour 
{ 
    public abstract void fired();

    public abstract int GetDamage();

    public abstract void OnTriggerEnter(Collider other);       
}
