using UnityEngine;
using System.Collections;

public class CloudSpawner : MonoBehaviour
{
    [Header("Cloud Prefabs")]
    public GameObject[] cloudPrefabs;

    [Header("Spawn Timing")]
    public float minSpawnDelay = 2f;
    public float maxSpawnDelay = 6f;

    [Header("Spawn Height")]
    public float minY = -2f;
    public float maxY = 4f;

    void Start()
    {
        StartCoroutine(SpawnClouds());
    }

    IEnumerator SpawnClouds()
    {
        while (true)
        {
            float delay = Random.Range(minSpawnDelay, maxSpawnDelay);
            yield return new WaitForSeconds(delay);

            SpawnCloud();
        }
    }

    void SpawnCloud()
    {
        GameObject prefab =
            cloudPrefabs[Random.Range(0, cloudPrefabs.Length)];

        float randomY = Random.Range(minY, maxY);

        Vector3 spawnPos = new Vector3(
            transform.position.x,
            randomY,
            0f
        );

        Instantiate(prefab, spawnPos, Quaternion.identity);
    }
    void OnDisable()
    {
        Debug.Log("CloudSpawner DISABLED");
    }

    void OnEnable()
    {
        Debug.Log("CloudSpawner ENABLED");
    }

}
