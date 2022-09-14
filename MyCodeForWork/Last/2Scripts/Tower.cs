using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] public Transform shootElement;
    [SerializeField] public Transform LookAtObj;
    [SerializeField] public GameObject bullet;

    public int dmg = 10;
    public Transform target;
    public float shootDelay;

    bool isShoot;
    
    
    void Update()
    {
        if (target)
        {
            LookAtObj.transform.LookAt(target);

            if (!isShoot)
            {
                StartCoroutine(shoot());
            }
        }
    }

    IEnumerator shoot()
    {
        isShoot = true;
        yield return new WaitForSeconds(shootDelay);
        GameObject b = GameObject.Instantiate(bullet, shootElement.position, Quaternion.identity) as GameObject;
        b.GetComponent<BulletTower>().target = target;
        b.GetComponent<BulletTower>().twr = this;
        isShoot = false;
    }
}
