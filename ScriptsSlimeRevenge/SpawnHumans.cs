using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnHumans : MonoBehaviour
{
    [SerializeField]
    private int waveNum, humansToSpawn, healthToSet, healthSettingStep;

    [SerializeField]
    private Transform[] humansSpawners;

    [SerializeField]
    private GameObject human;

    private void Start()
    {
        waveNum = 1;
        humansToSpawn = 1;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SpawnHuman();
        }
    }

    public void SpawnHuman()
    {
        for (int i = 0; i < humansToSpawn; i++)
        {
            GameObject obj = Instantiate(human, humansSpawners[i].position, Quaternion.identity);
            obj.GetComponent<Health>().SetMaxHealth(healthToSet);
        }
    }

    public void WaveUpdate()
    {
        waveNum++;

        if (waveNum > 2)
        {
            humansToSpawn = 2;
        }

        if (waveNum > 5)
        {
            humansToSpawn = 3;
        }

        if (waveNum > 9)
        {
            humansToSpawn = 1;
            waveNum = 1;

            healthToSet += healthSettingStep;
        }
    }
}
