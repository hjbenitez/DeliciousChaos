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
            if(GameManager.spawnedEnemies < GameManager.maxEnemyCount && GameManager.CheckLayerCount(enemy.layer) && !GameManager.playerDead)
            {
                Instantiate(enemy, transform.position, transform.rotation);
                GameManager.IncremenentEnemyCounter(enemy.layer);
            }

            spawnTimer = 0;
        }

        else
        {
            spawnTimer += Time.deltaTime;
        }
    }
}
