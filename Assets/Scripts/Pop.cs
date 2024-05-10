using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pop : Projectile
{
    float lifeTimer;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        speed = 10f;
        lifeTime = 5f;
        damage = 1f;
        lifeTimer = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = transform.forward * speed;

        lifeTimer += Time.deltaTime;

        if(lifeTimer > lifeTime)
        {
            Destroy(gameObject);
        }
    }

    public override void fired()
    {
        throw new System.NotImplementedException();
    }
}
