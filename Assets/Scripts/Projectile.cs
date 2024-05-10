using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    Rigidbody rb;
    float speed = 10f;
    float lifeTime = 5f;
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

        if(lifeTimer > lifeTime)
        {
            Destroy(gameObject);
        }
    }
}
