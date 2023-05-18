using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour
{
    public GameObject[] platfomPrefabs;
    private float spawnPos = 0;
    private float platformLength = 100;
    private int startPlatforms = 6;
    [SerializeField] private Transform player;
    private List<GameObject> activePlatforms = new List<GameObject>();


    void Start()
    {
        for (int i = 0; i < startPlatforms; i++)
        {
            SpawnPlatform(Random.Range(0, platfomPrefabs.Length));
        }
    }

   
    void Update()
    {
        if (player.position.z - 80 > spawnPos - (platformLength * startPlatforms))
        {
            SpawnPlatform(Random.Range(0, platfomPrefabs.Length));
            DeletePlatform();
        }
       
    }

    void SpawnPlatform(int platformIndex )
    {
      
        GameObject nextPlatform = Instantiate(platfomPrefabs[platformIndex], transform.forward * spawnPos, transform.rotation);
        activePlatforms.Add(nextPlatform);
        spawnPos += platformLength;


    }

    private void DeletePlatform()
    {
        Destroy(activePlatforms[0]);
        activePlatforms.RemoveAt(0);
    }
}

