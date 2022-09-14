using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Health), typeof(Rigidbody), typeof(Collider))]
public class TargetHit : MonoBehaviour
{
    private Health _health;

    private void Awake()
    {
        _health = gameObject.GetComponent<Health>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ObjectHit"))
        {
            _health.AplyDamage(50);
        }
    }

    public void MakeDebug()
    {
        Debug.Log("Попадание");
    }
}
