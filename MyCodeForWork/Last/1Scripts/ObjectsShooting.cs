using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectsShooting : MonoBehaviour
{
    [SerializeField]
    private GameObject ball;

    [SerializeField]
    private GameObject gunPivotObj;

    [SerializeField]
    private GameObject bomb;

    [SerializeField]
    private GameObject coin;

    [SerializeField]
    private Transform spawn;

    [SerializeField]
    private float speedObject;

    [SerializeField]
    private float delayFirstShoot;

    [SerializeField]
    private float delayShoot;

    [SerializeField]
    private Transform[] popintsToFLy;

    private GameObject obj;
    private int randNum;

    private void Start()
    {
        InvokeRepeating("Shoot", delayFirstShoot, delayShoot);
    }

    private void Shoot()
    {
        randNum = Random.Range(0, 10);

        if (randNum == 9 || randNum == 10)
        {
            obj = Instantiate(bomb, spawn.position, transform.rotation);
        }
        else if (randNum == 7 || randNum == 8)
        {
            obj = Instantiate(coin, spawn.position, transform.rotation);
        }
        else
        {
            obj = Instantiate(ball, spawn.position, transform.rotation);
        }

        obj.GetComponent<Rigidbody>().AddForce(spawn.forward * speedObject, ForceMode.Impulse);
    }
}
