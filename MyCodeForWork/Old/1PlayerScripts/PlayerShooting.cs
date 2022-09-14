using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform spawnPosition;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shooting();
        }

        Debug.DrawRay(spawnPosition.position, spawnPosition.forward * 3, Color.red);
    }

    private void Shooting()
    {
        Instantiate(bullet, spawnPosition.position, spawnPosition.rotation);
    }
}
