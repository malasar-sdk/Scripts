using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject enemy;

    [SerializeField]
    private float spawnDelay;

    [SerializeField]
    private Transform[] spawners;

    private int _numSpawn;

    private void Start()
    {
        InvokeRepeating("SpawnEnemy", spawnDelay, spawnDelay);
    }

    private void SpawnEnemy()
    {
        _numSpawn = Random.Range(0, 3);

        Instantiate(enemy, spawners[_numSpawn].position,Quaternion.identity );
    }
}
