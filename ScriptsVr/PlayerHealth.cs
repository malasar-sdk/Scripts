using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerHealth : MonoBehaviour
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
    }

    public float GetHealth()
    {
        return health;
    }
}
