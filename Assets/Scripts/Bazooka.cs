using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bazooka : Projectile
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
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = transform.forward * speed;

        lifeTimer += Time.deltaTime;

        if (lifeTimer > lifeTime)
        {
            Destroy(gameObject);
        }
    }

    public override void fired()
    {
        throw new System.NotImplementedException();
    }
}
