using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineGun : Projectile
{
    public Rigidbody rb;
    public float speed = 10f;
    public float lifeTime = 5f;
    public float damage = 1f;
    float lifeTimer = 0f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        speed = 10f;
        lifeTime = 5f;
        damage = 1f;
        lifeTimer = 0f;

        fired();
    }

    public override void fired()
    {
        rb.velocity = transform.forward * speed;

        lifeTimer += Time.deltaTime;

        if (lifeTimer > lifeTime)
        {
            Destroy(gameObject);
        }
    }
}
