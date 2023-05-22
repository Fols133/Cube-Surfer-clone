using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingLevel : MonoBehaviour
{
    [SerializeField] private GameObject pickupPref;
    [SerializeField] private List<GameObject> wallPrefs = new List<GameObject>();
    [SerializeField] private GameObject platformPref;
    [SerializeField] private GameObject startPlatformObj;
    [SerializeField] private Transform player;

    [SerializeField] private int countSpawnPlatform = 4;
    [SerializeField] private int countSpawnPickupPlatform = 3;
    [SerializeField] private int fieldLimit = 2;

    private float maxDistanceSpawnPickup;
    private float distanceBetweenPickup;
    private float platformsLenght;
    private float spawnPos;

    private List<GameObject> platformsList = new List<GameObject>();

    void Start()
    {
        platformsList.Add(startPlatformObj);
        platformsLenght = platformPref.transform.localScale.z;
        spawnPos = platformsLenght;
        maxDistanceSpawnPickup = countSpawnPickupPlatform / 4f;
        distanceBetweenPickup = maxDistanceSpawnPickup / countSpawnPickupPlatform;
        for (int i = 0; i < countSpawnPlatform; i++)
        {
            SpawnPlatform();
        }
    }

    void Update()
    {
        if ((player.position.z - platformsLenght) > spawnPos - (countSpawnPlatform * platformsLenght))
        {
            SpawnPlatform();
            RemovePlatform();
        }
    }

    public void SpawnPlatform()
    {
        GameObject platform = Instantiate(platformPref, transform.forward * spawnPos, Quaternion.identity);
        spawnPos += platformsLenght;
        platformsList.Add(platform);
        SpawnObject(platform.transform);
    }

    private void RemovePlatform()
    {
        Destroy(platformsList[0]);
        platformsList.RemoveAt(0);
    }

    private void SpawnObject(Transform platform)
    {
        for (int i = -fieldLimit; i <= fieldLimit; i++)
        {
            int indexRandom = Random.Range(0, wallPrefs.Count - 1);
            Vector3 posWall = platform.position + (Vector3.forward * platformsLenght);
            posWall.x = i;
            GameObject wall = Instantiate(wallPrefs[indexRandom], posWall, Quaternion.identity);
            wall.transform.SetParent(platform);
        }
        for (float i = distanceBetweenPickup; i <= maxDistanceSpawnPickup; i += distanceBetweenPickup)
        {
            Vector3 posPickup = platform.position + (Vector3.up * 0.5f) + Vector3.forward * (i * platformsLenght) + (Vector3.right * Random.Range(-fieldLimit, fieldLimit));
            Instantiate(pickupPref, posPickup, Quaternion.identity);
        }
    }
}
