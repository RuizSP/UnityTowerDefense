using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Spawner : MonoBehaviour
{
    private bool bossSpawned = false;
    public static Enemy_Spawner instance;
    void Awake()
    {
        instance = this;
    }

    [SerializeField] private List<GameObject> prefabs;
    public List<Transform> spawnPoints;
    [SerializeField] private int waveCounter = 0;
    [SerializeField] private int wave1, wave2, wave3, wave4;
    [SerializeField] private float spawnInterval = 4f;

    public void StartSpawning()
    {
        StartCoroutine(SpawnTimer());
    }

    private void Start()
    {
        StartSpawning();
    }

    /*IEnumerator WaveInterval()
    {
        if(waveCounter >= waveTimer)
        {
            yield return new WaitForSeconds(waveTimer);
        }
        else
        {
            yield return new WaitForSeconds(0);
        }

        StartCoroutine(WaveInterval());
    }*/

    IEnumerator SpawnTimer()
    {
        SpawnEnemy();
        
        yield return new WaitForSeconds(spawnInterval);

        //StartCoroutine(WaveInterval());
        StartCoroutine(SpawnTimer());
    }

    private int waveSelector()
    {
        if(waveCounter > wave4 && !bossSpawned)
        {
            return 4;
        }
        else if(waveCounter > wave3)
        {
            return Random.Range(0,4);
        }
        else if(waveCounter > wave2)
        {
            return Random.Range(0,3);
        }
        else if(waveCounter > wave1)
        {
            return Random.Range(0,2);
        }
        else
        {
            return 0;
        }
    }

    void SpawnEnemy()
    {
        waveCounter += 1;
        int randomSpawnPointID = Random.Range(0,spawnPoints.Count);
        GameObject spawnedEnemy = Instantiate(prefabs[waveSelector()], spawnPoints[randomSpawnPointID]);
    }
}
