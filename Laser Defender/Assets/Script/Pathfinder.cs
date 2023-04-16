using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour
{
    EnemySpawn enemySpawner;
    WaveConfigSo waveConfig;
    List<Transform> waypoints;
    int waypointIdx = 0;

    private void Awake()
    {
        enemySpawner = FindObjectOfType<EnemySpawn>();
    }
    void Start()
    {
        waveConfig = enemySpawner.getCurrentWave();
        waypoints = waveConfig.GetWaypoints();
        transform.position = waypoints[waypointIdx].position;
    }

    void Update()
    {
        FollwPath();   
    }

    void FollwPath()
    {
       if(waypointIdx < waypoints.Count) 
        {
            Vector3 targetPosition = waypoints[waypointIdx].position;
            float delta = waveConfig.GetMoveSpeed() * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, delta);
            if(transform.position == targetPosition)
            {
                waypointIdx++;
            }
        }
        else 
        {
            Destroy(gameObject);
        }
    }
}
