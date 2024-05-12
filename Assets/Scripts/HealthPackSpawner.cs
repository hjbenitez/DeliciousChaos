using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPackSpawner : MonoBehaviour
{
    public List<GameObject> SpawnPoints;
    public GameObject healthPackPrefab;

    public List<int> spawnPointsUsed;
    
    // Start is called before the first frame update
    void Start()
    {
        RespawnHealthPack();
        RespawnHealthPack();
        RespawnHealthPack();
    }

    public void RespawnHealthPack()
    {
            int point;

            while (true)
            {
                bool isUsed = false;
                
                point = Random.Range(0, SpawnPoints.Count);

                foreach (int e in spawnPointsUsed)
                {
                    if(point == e)
                    {
                        isUsed = true;
                    }
                }

                if(isUsed == false)
                {
                    break;
                }
            }

            Instantiate(healthPackPrefab, SpawnPoints[point].transform.position, healthPackPrefab.transform.rotation);

            spawnPointsUsed.Add(point);
    }

    // Update is called once per frame
    void Update()
    {
        if(spawnPointsUsed.Count > 6)
        {
            spawnPointsUsed.Clear();
        }
    }
}
