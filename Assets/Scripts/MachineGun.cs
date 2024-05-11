using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineGun : Projectile
{
    Rigidbody rb;
    public float speed = 10f;
    public float lifeTime = 5f;
    public int damage = 1;
    public float fireRate = 0.25f;
    float lifeTimer = 0f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        fired();

    }

    void Update()
    {
        lifeTimer += Time.deltaTime;

        if (lifeTimer > lifeTime)
        {
            Destroy(gameObject);
        }
    }

    public override void fired()
    {
        rb.velocity = transform.forward * speed;
    }

    public override float GetFireRate()
    {
        return fireRate;
    }

    public override int GetDamage()
    {
        return damage;
    }
}