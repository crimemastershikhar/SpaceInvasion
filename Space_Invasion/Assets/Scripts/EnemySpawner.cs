using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject EnemyGO; //Enemy Prefab
    public float maxSpawnRateInSeconds;
    private void Start()
    {
    }
    void SpawnEnemy()
    {
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0)); //Spawning at bottom left
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1)); //Spawning at top right
        GameObject anEnemy = (GameObject)Instantiate(EnemyGO);
        //Instantiate Enemy
        anEnemy.transform.position = new Vector2(Random.Range(min.x, max.x), max.y);
        ScheduleNextEnemySpawn();
    }
    void ScheduleNextEnemySpawn()
    {
        float spawnInSeconds;
        if (maxSpawnRateInSeconds > 1f)
        {
            spawnInSeconds = Random.Range(1f, maxSpawnRateInSeconds); //picking a no. b/w 1 and maxspawnrateinseconds
        }
        else
            spawnInSeconds = 1f;
        Invoke("SpawnEnemy", spawnInSeconds);
    }
    void IncreaseSpawnRate() //Toincreasedifficulty
    {
        if (maxSpawnRateInSeconds > 1f)
            maxSpawnRateInSeconds--;
        if (maxSpawnRateInSeconds == 1f)
            CancelInvoke("IncreaseSpawnRate");
    }
    public void ScheduleEnemySpawner() //startenemyspawn
    {
        Invoke("SpawnEnemy", maxSpawnRateInSeconds);
        InvokeRepeating("IncreaseSpawnRate", 0f, 50f);
    }
    public void UnscheduleEnemySpawner()//To stop enemy from spawwning afte player dies
    {
        CancelInvoke("SpawnEnemy");
        CancelInvoke("IncreaseSpawnRate");
    }

}
