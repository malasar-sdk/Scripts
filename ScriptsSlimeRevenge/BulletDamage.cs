using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDamage : MonoBehaviour
{
    public static int damage;

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag.Equals("Enemy"))
        {
            col.gameObject.GetComponent<Health>().AplyDamage(damage);
            Destroy(gameObject);
        }
    }
}
