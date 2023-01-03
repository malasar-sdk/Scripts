using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HumansDetection : MonoBehaviour
{
    [SerializeField]
    private float rotationSpeed;

    [SerializeField]
    private bool isDetected;

    [SerializeField]
    private GameObject[] humansMas;

    [SerializeField]
    private Transform environment;

    [SerializeField]
    private PlayerShooting playerShooting;

    [SerializeField]
    private SpawnHumans spawnHumans;

    public static bool isDestroyed;

    private int _numInMas;

    private void Start()
    {
        isDetected = false;
        isDestroyed = true;

        _numInMas = 0;
    }

    private void Update()
    {
        RotateEnvironment();
        DetectionEnd();
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag.Equals("EnemyChecking"))
        {
            isDetected = true;
            playerShooting.IsDetectedHuman(true);

            humansMas[_numInMas] = col.gameObject;
            _numInMas++;
        }
    }

    private void DetectionEnd()
    {
        if (isDestroyed == true && humansMas[0] == null && humansMas[1] == null && humansMas[2] == null)
        {
            isDetected = false;
            playerShooting.IsDetectedHuman(false);

            humansMas = new GameObject[3];
            _numInMas = 0;

            spawnHumans.SpawnHuman();

            isDestroyed = false;
        }
    }

    private void RotateEnvironment()
    {
        if (isDetected == false)
        {
            environment.Rotate(0, -rotationSpeed, 0);
        }
        else
        {
            environment.Rotate(0, 0, 0);
        }
    }
}
