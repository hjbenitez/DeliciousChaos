using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    public GameObject enemy;

    public float spawnTime = 5f;
    public float offset;
    float spawnTimer = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (spawnTimer > spawnTime)
        {
            if(StaticValues.enemyCount < StaticValues.maxEnemyCount && StaticValues.CheckLayerCount(gameObject.layer))
            {
                Instantiate(enemy, transform.position, transform.rotation);
                StaticValues.IncremenentEnemyCounter(gameObject.layer);
            }

            spawnTimer = 0;
        }

        else
        {
            spawnTimer += Time.deltaTime;
        }
    }
}
