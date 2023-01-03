using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class ShootingPlayer : MonoBehaviour
{
    [SerializeField]
    private SteamVR_Action_Boolean shoot;

    [SerializeField]
    private GameObject bullet;

    [SerializeField]
    private Transform spawner;

    private void Update()
    {
        Shoot();
    }

    private void Shoot()
    {
        if (shoot.lastStateDown == true || Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(bullet, spawner.position, spawner.rotation);
        }
    }
}
