using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTruck : MonoBehaviour
{
    public GameObject spawnPoint;
    public GameObject truckPrefab;
    public GameObject Truck;
    public float minSpawnTime = 1f;
    public float maxSpawnTime = 4;
    private float lastSpawnTime = 0;
    private float spawnTime = 0;
    void Start()
    {
        UpdateSpawnTime(); 
    }
    void UpdateSpawnTime()
    {
        lastSpawnTime = Time.time;
        spawnTime = Random.Range(minSpawnTime, maxSpawnTime);
    }
    void Spawn()
    {
        Instantiate(Truck, spawnPoint.transform.position, Quaternion.identity);
        UpdateSpawnTime();
    }
    void Update()
    {
        if (Time.time >= lastSpawnTime + spawnTime)
        {
            Spawn();
        }
    }
}