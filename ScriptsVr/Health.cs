using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [SerializeField]
    private float health;

    [SerializeField]
    private UnityEvent dethEvent;

    public void AplyDamage(float dmg)
    {
        health -= dmg;

        if (health <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        dethEvent.Invoke();

        Destroy(gameObject);
    }

    public float GetHealth()
    {
        return health;
    }
}
