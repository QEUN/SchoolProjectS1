using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnMananger : MonoBehaviour
{
    // the floats needed for the spawnlocations
    public GameObject[] SpawnBullshit;
    private float UpperLimmit = 5.0f;
    private float LowerLimmit = -3.0f;
    private float RightLimmit = 6.0f;
    private float LeftLimmit = -6.0f;
    private float startDelay = 2.0f;
    private float spawnInterval = 1.5f;

    
    // spawns what is needed
    void Start()
    {
        InvokeRepeating("SpawnRandomLocation", startDelay, spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    // makes sure we can spawn bullshit
    void SpawnRandomLocation()
    {
        int SpawnSint = Random.Range(0,SpawnBullshit.Length);
        Vector3 spawnPos = new Vector3(Random.Range(UpperLimmit, LowerLimmit), 0, Random.Range(LeftLimmit, RightLimmit));

        Instantiate(SpawnBullshit[SpawnSint], spawnPos, SpawnBullshit[SpawnSint].transform.rotation);

    }
}
