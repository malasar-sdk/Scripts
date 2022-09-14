using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [SerializeField]
    private float healthValue = 100;

    [SerializeField]
    private UnityEvent dethAction;

    public void AplyDamage(float dmg)
    {
        healthValue -= dmg;

        if (healthValue <= 0)
        {
            Deth();
        }
    }

    private void Deth()
    {
        dethAction.Invoke();

        Destroy(gameObject, 1);
    }

    public float GetHealth()
    {
        return healthValue;
    }
}
