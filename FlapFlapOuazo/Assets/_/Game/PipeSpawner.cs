using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    [Header("Pipe Settings")]
    public GameObject pipePrefab;

    [Header("Spawn Timing")]
    public float spawnRate = 2f;
    public float startDelay = 4f;

    [Header("Spawn Spacing")]
    public float spawnDistance = 2f;

    private float nextSpawnX;

    private void Start()
    {
        nextSpawnX = transform.position.x;
        InvokeRepeating(nameof(SpawnPipe), startDelay, spawnRate);
    }

    void SpawnPipe()
    {
        float randomY = Random.Range(-2f, 2f);

        Vector3 spawnPos = new Vector3(
            nextSpawnX,
            randomY,
            0f
        );

        Instantiate(pipePrefab, spawnPos, Quaternion.identity);

       
    }

}
