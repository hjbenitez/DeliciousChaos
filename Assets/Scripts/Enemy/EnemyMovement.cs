using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class EnemyMovement : MonoBehaviour
{
    public NavMeshAgent agent;
    public Rigidbody rb;
    public GameObject enemyHealthBarPrefab;
    public Transform healthBarSpawnLocation;
    private GameObject healthCanvas;

    private Image hpBar;
    private GameObject player;

    public float maxHealth;
    private float currentHealth;
    private bool dead;
    
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        
        player = GameObject.FindGameObjectWithTag("Player");

        healthCanvas = Instantiate(enemyHealthBarPrefab, healthBarSpawnLocation.position, enemyHealthBarPrefab.transform.rotation);
        healthCanvas.transform.SetParent(GameObject.Find("EnemyHpBarHolder").transform);
        EnemyCanvas ec = healthCanvas.GetComponent<EnemyCanvas>();
        ec.canvasPos = this.transform;
        hpBar = ec.healthBar;
    }

    // Update is called once per frame
    void Update()
    {
        if (!dead)
        {
            agent.SetDestination(player.transform.position);
        }


        if (Input.GetKeyDown("h"))
        {
            TakeDamage(1);
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        hpBar.fillAmount = (float)currentHealth / (float)maxHealth;

        if(currentHealth <= 0)
        {
            dead = true;
            agent.isStopped = true;
            rb.isKinematic = false;
            rb.AddForce(this.transform.position - player.transform.position, ForceMode.Impulse);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == 6)
        {
            TakeDamage(1);
        }
    }
}
