using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    // the floats needed for the spawnlocations
    public GameObject[] spawnBullshit;
    private const float upperLimmit = 5.265f;
    private const float lowerLimmit = -3.27f;
    private const float rightLimmit = 8.307f;
    private const float leftLimmit = -8.307f;
    private const float startDelay = 1.0f;
    private const float spawnInterval = 1.5f;

    
    // spawns what is needed
    void Start()
    {
        SpawnRandomLocation();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    // makes sure we can spawn bullshit
    public void SpawnRandomLocation()
    {
        int spawnIndex = Random.Range(0, spawnBullshit.Length);
        Vector3 spawnPos = new Vector3(Random.Range(leftLimmit, rightLimmit), Random.Range(lowerLimmit, upperLimmit), -5.0f);

        Instantiate(spawnBullshit[spawnIndex], spawnPos, spawnBullshit[spawnIndex].transform.rotation);
    }
}
