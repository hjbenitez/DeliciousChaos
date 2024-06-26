using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fork : Projectile
{
    public float speed = 10f;
    public float lifeTime = 5f;
    public int damage = 1;
    public float fireRate = 0.25f;
    public GameObject cakeSplatter;

    Rigidbody rb;
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

    public override int GetDamage()
    {
        return damage;
    }

    public override void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer != 3 && other.gameObject.layer != 8 && other.gameObject.layer != 9 && other.gameObject.layer != 11)
        {
            if(other.gameObject.tag == "Enemy")
            {
                other.gameObject.GetComponent<EnemyController>().TakeDamage(damage);
                GameObject temp = Instantiate(cakeSplatter, transform.position, transform.rotation);
                temp.GetComponent<AudioSource>().volume = GameManager.SetSFXVolume(0.5f); 
            }

            Destroy(gameObject);
        }
    }
}
