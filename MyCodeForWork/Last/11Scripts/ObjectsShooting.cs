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
    private Transform gunPivot;

    [SerializeField]
    private float speedObject;

    [SerializeField]
    private float delayFirstShoot;

    [SerializeField]
    private float delayShoot;

    [SerializeField]
    private Transform[] popintsToFLy;

    private GameObject _obj;
    private int _randNum;
    private Vector3 shootVector;

    private void Start()
    {
        InvokeRepeating("Shoot", delayFirstShoot, delayShoot);
    }

    private void Shoot()
    {
        _randNum = Random.Range(0, 5);
        shootVector = popintsToFLy[_randNum].position - transform.position;

        transform.LookAt(shootVector);

        _randNum = Random.Range(0, 10);

        if (_randNum == 9 || _randNum == 10)
        {
            _obj = Instantiate(bomb, spawn.position, transform.rotation);
        }
        else if (_randNum == 7 || _randNum == 8)
        {
            _obj = Instantiate(coin, spawn.position, transform.rotation);
        }
        else
        {
            _obj = Instantiate(ball, spawn.position, transform.rotation);
        }

        _obj.GetComponent<Rigidbody>().AddForce(spawn.forward * speedObject, ForceMode.Impulse);
    }

    public void StartShooting()
    {
        InvokeRepeating("Shoot", delayFirstShoot, delayShoot);
    }
}
