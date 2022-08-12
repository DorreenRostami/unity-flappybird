using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    public GameObject prefab;

    private float maxHeight = 2f;
    private float minHeight = -2f;

    private float spawnTimer = 0;
    private float spawnTimerMax = 3f;
    private int pipesSpawned = 0;

    public void resetSpawner()
    {
        spawnTimer = 0;
        spawnTimerMax = 3f;
        pipesSpawned = 0;
    }

    private void Update()
    {
        spawnTimer -= Time.deltaTime;
        if(spawnTimer < 0)
        {
            spawnTimer += spawnTimerMax;
            SpawnPipes();
            pipesSpawned += 1;
        }
        if(pipesSpawned > 5)
        {
            pipesSpawned = 0;
            if(spawnTimerMax > 0.9)
            {
                spawnTimerMax -= 0.5f;
            }
        }
    }

    private void SpawnPipes()
    {
        GameObject pipes = Instantiate(prefab, transform.position, Quaternion.identity);
        pipes.transform.position += Vector3.up * Random.Range(minHeight, maxHeight);
    }
}
