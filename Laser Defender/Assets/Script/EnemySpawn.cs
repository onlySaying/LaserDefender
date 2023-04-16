using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField] List<WaveConfigSo> waveConfig;
    [SerializeField] float timeBetweenWaves;
    WaveConfigSo currentWave;
    [SerializeField] bool isLooping;
    void Start()
    {
        StartCoroutine(SpawnEnemyWaves());
    }

    IEnumerator SpawnEnemyWaves()
    {
        do
        {
            foreach (WaveConfigSo wave in waveConfig)
            {
                currentWave = wave;
                for (int i = 0; i < currentWave.getEnemyCount(); i++)
                {
                    Instantiate(currentWave.getEnemyPrefab(i), currentWave.GetStartingWaypoint().position, Quaternion.Euler(0,0,180)
                    , transform);

                    yield return new WaitForSeconds(currentWave.GetRandomSpawnTime());
                }
                yield return new WaitForSeconds(timeBetweenWaves);
            }
        }while(isLooping);

           
    }

    public WaveConfigSo getCurrentWave()
    {
        return currentWave;
    }
}
