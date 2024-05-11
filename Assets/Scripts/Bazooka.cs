using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class Bazooka : Projectile
{
    Rigidbody rb;
    public float speed = 50f;
    public float lifeTime = 5f;
    public int damage = 3;
    public float fireRate = 2.5f;
    float lifeTimer = 0f;

    float initialSpeedTime = 0;
    float damageRadius = 5f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        lifeTimer += Time.deltaTime;

        if (lifeTimer > lifeTime)
        {
            Destroy(gameObject);
        }

        if (lifeTimer < initialSpeedTime)
        {
            rb.velocity = transform.forward * 2.0f;
        }

        else
        {
            rb.velocity = Vector3.Lerp(transform.forward * 2.0f, transform.forward * speed, (lifeTimer - initialSpeedTime) / 1f);
        }
    }

    public override void fired()
    {
        throw new System.NotImplementedException();
    }

    public override float GetFireRate()
    {
        return fireRate;
    }

    public override int GetDamage()
    {
        return damage;
    }

    public override void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer != 3 && other.gameObject.layer != 8 && other.gameObject.layer != 9)
        {
            Collider[] enemies = Physics.OverlapSphere(transform.position, damageRadius);
            foreach(Collider collider in enemies)
            {
                if (collider.gameObject.tag == "Enemy")
                {
                    print(collider.gameObject.name);
                    collider.gameObject.GetComponent<EnemyMovement>().TakeDamage(damage);
                }
            }

            Destroy(gameObject);
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, damageRadius);
        Gizmos.color = Color.yellow;
    }
}
