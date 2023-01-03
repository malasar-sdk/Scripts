using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMace : MonoBehaviour
{
    [SerializeField]
    private float damage = 10f;

    [SerializeField]
    private string enemyTag = "Player";

    private void OnCollisionEnter(Collision col)
    {
        if (col.collider.CompareTag(enemyTag))
        {
            col.collider.SendMessageUpwards("AplyDamage", damage);
        }
    }
}
