using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField]
    private float shootForce, curAttackSpeed;

    [SerializeField]
    private bool isDetected;

    [SerializeField]
    private GameObject bullet;

    [SerializeField]
    private Transform bulletSpawner;

    public static float maxAttackSpeed;

    private void Start()
    {
        curAttackSpeed = maxAttackSpeed;
    }

    private void Update()
    {
        Shooting();
    }

    private void Shooting()
    {
        if (isDetected == true)
        {
            if (curAttackSpeed > 0)
            {
                curAttackSpeed -= Time.deltaTime;
            }
            else
            {
                GameObject obj = Instantiate(bullet, bulletSpawner.position, bulletSpawner.rotation);
                Rigidbody rb = obj.GetComponent<Rigidbody>();
                rb.AddForce(bulletSpawner.forward * shootForce, ForceMode.Impulse);

                curAttackSpeed = maxAttackSpeed;
            }
        }
        else
        {
            curAttackSpeed = maxAttackSpeed;
        }
    }

    public void IsDetectedHuman(bool x)
    {
        isDetected = x;
    }
}
