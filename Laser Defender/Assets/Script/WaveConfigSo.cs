using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "wave Config", fileName = "New Wave Config")]

public class WaveConfigSo : ScriptableObject
{
    [SerializeField] List<GameObject> ememyPrefabs;
    [SerializeField] Transform pathPrefab;
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float timeBetweenEnemySpawns = 1f;
    [SerializeField] float spawnTimeVariance = 0f;
    [SerializeField] float minimumSpawnTime = 0.2f;

    public Transform GetStartingWaypoint() { return pathPrefab.GetChild(0); }

    public List<Transform> GetWaypoints()
    { 
        List<Transform> waypoints = new List<Transform>();

        foreach(Transform child in pathPrefab)
        {
            waypoints.Add(child);
        }
        return waypoints;
    }
    public float GetMoveSpeed()
    { return moveSpeed; }

    public int getEnemyCount()
    { return ememyPrefabs.Count;}

    public GameObject getEnemyPrefab(int index)
    { return ememyPrefabs[index];}

    public float GetRandomSpawnTime()
    {
        float spawnTime = Random.Range(timeBetweenEnemySpawns - spawnTimeVariance, 
            timeBetweenEnemySpawns + spawnTimeVariance);
        return Mathf.Clamp(spawnTime, minimumSpawnTime, float.MaxValue);
    }
}
