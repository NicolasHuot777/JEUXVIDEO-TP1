using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalSpawner : MonoBehaviour
{
    public GameObject[] animalPrefabs;
    private float zTopSpawnRangePosition = 20;
    private float zBottomSpawnRangePosition = -5;
    private float ySpawnPosition = 0;
    private float xSpawnPosition = 18;
    private float startDelay = 2;
    private float spawnInterval = 2.5f;


    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnRandomAnimals", startDelay, spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnRandomAnimals()
    {
        int animalIndex = Random.Range(0, animalPrefabs.Length);
        Vector3 spawnPosition = new Vector3(xSpawnPosition, ySpawnPosition, Random.Range(zTopSpawnRangePosition, zBottomSpawnRangePosition));
        Instantiate(animalPrefabs[animalIndex], spawnPosition, animalPrefabs[animalIndex].transform.rotation);
    }
}
