using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponAttack : MonoBehaviour
{
    [SerializeField]
    private float attackForce;

    [SerializeField]
    private string enemyTag;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag(enemyTag))
        {
            collision.collider.SendMessageUpwards("AplyDamage", attackForce);
        }
    }
}
