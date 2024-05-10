using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public abstract class Projectile : MonoBehaviour
{
    public Rigidbody rb;
    public float speed;
    public float lifeTime;
    public float damage;

    public abstract void fired();
}
