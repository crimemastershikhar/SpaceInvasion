using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject EnemyGO; 
    [SerializeField] private float maxSpawnRateInSeconds = 1f;
    private void Start()
    {
    }
    void SpawnEnemy()
    {
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0)); 
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1)); 
        GameObject anEnemy = (GameObject)Instantiate(EnemyGO);        
        anEnemy.transform.position = new Vector2(Random.Range(min.x, max.x), max.y);
        ScheduleNextEnemySpawn();
    }
    void ScheduleNextEnemySpawn()
    {
        float spawnInSeconds;
        if (maxSpawnRateInSeconds >= 1f)
        {
            spawnInSeconds = Random.Range(1f, maxSpawnRateInSeconds); 
        }
        else
            spawnInSeconds = 1f;
        Invoke("SpawnEnemy", spawnInSeconds);
    }
    void IncreaseSpawnRate() 
    {
        if (maxSpawnRateInSeconds > 1f)
            maxSpawnRateInSeconds--;
        if (maxSpawnRateInSeconds == 0.5f)
            CancelInvoke("IncreaseSpawnRate");
    }
    public void ScheduleEnemySpawner() 
    {
        maxSpawnRateInSeconds = 1f; 
        Invoke("SpawnEnemy", maxSpawnRateInSeconds);
        InvokeRepeating("IncreaseSpawnRate", 0f, 50f);
    }
    public void UnscheduleEnemySpawner()
    {
        CancelInvoke("SpawnEnemy");
        CancelInvoke("IncreaseSpawnRate");
    }

}
