using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private Transform[] spawners;

    [SerializeField]
    private GameObject enemy;

    [SerializeField]
    private float spawnDelay;

    private Transform _curSpawnPoint;

    private void Start()
    {
        InvokeRepeating("Spawner", spawnDelay, spawnDelay);
    }

    private void Spawner()
    {
        _curSpawnPoint = spawners[Random.Range(0, spawners.Length - 1)];

        Instantiate(enemy, _curSpawnPoint.position, _curSpawnPoint.rotation);
    }

    public void SpawnTimeUpdate()
    {
        if (spawnDelay > 1.2f)
        {
            spawnDelay -= 0.2f;
        }
    }
}
