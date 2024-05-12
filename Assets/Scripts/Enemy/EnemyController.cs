using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour
{
    public NavMeshAgent agent;
    public List<Rigidbody> rbs;
    public GameObject damager; 
    public GameObject enemyHealthBarPrefab;
    public Transform healthBarSpawnLocation;
    private GameObject healthCanvas;
    public Animator anim;
    public AudioSource source;
    public AudioClip[] deathSounds;

    private Image hpBar;
    private GameObject player;

    public float maxHealth;
    private float currentHealth;
    private bool dead;
    private bool deathSound;
    
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        
        player = GameObject.FindGameObjectWithTag("Player");

        healthCanvas = Instantiate(enemyHealthBarPrefab, healthBarSpawnLocation.position, enemyHealthBarPrefab.transform.rotation);
        healthCanvas.transform.SetParent(GameObject.Find("EnemyHpBarHolder").transform);
        EnemyCanvas ec = healthCanvas.GetComponent<EnemyCanvas>();
        ec.canvasPos = healthBarSpawnLocation;
        hpBar = ec.healthBar;
    }

    // Update is called once per frame
    void Update()
    {
        if (!dead)
        {
            agent.SetDestination(player.transform.position);
        }

        else
        {
            if(!deathSound)
            {
                int sound = Random.Range(0, 3);
                source.clip = deathSounds[sound];
                source.Play();
                deathSound = true;
            }

            if(deathSound && !source.isPlaying)
            {
                Destroy(gameObject);
            }
        }

        if (Input.GetKeyDown("h"))
        {
            TakeDamage(1);
        }
            
        if(StaticValues.playerDead == true)
        {
            TakeDamage(10000);
        }
    }
    
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        hpBar.fillAmount = (float)currentHealth / (float)maxHealth;

        if(currentHealth <= 0)
        { 
            dead = true;
            Destroy(agent);
            Destroy(healthCanvas);
            Destroy(damager);
            Destroy(anim);
            Destroy(this.gameObject.GetComponent<BoxCollider>());

            transform.DetachChildren();
            float minForce = 3f;

            foreach(Rigidbody rigidbody in rbs)
            {
                float randomForce = Random.Range(minForce, 10f);

                if (randomForce < 1)
                {
                    minForce = 1;
                }

                rigidbody.isKinematic = false;
                rigidbody.AddForce((this.transform.position - player.transform.position).normalized * randomForce, ForceMode.Impulse);
                rigidbody.gameObject.layer = 12;
            }

            /*
            for (int i = 0; i < rbs.Count; i++)
            {
                float randomForce = Random.Range(minForce, 2f);

                if(randomForce < 1)
                {
                    minForce = 1;
                }
                
                rbs[i].isKinematic = false;
                rbs[i].AddForce((this.transform.position - player.transform.position).normalized * (i * randomForce),  ForceMode.Impulse);
            }*/
        }  
    }
}
