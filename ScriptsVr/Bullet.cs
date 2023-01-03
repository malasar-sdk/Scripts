using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    private float damage = 50f, speed = 10f, delayToDestroy = 3f;

    [SerializeField]
    private string enemyTag = "Enemy";

    private void Start()
    {
        Invoke("DestroyThis", delayToDestroy);
    }

    private void Update()
    {
        Flying();
    }

    private void Flying()
    {
        transform.position += transform.forward * speed * Time.deltaTime;
    }

    private void DestroyThis()
    {
        Destroy(this.gameObject);
    }

    private void OnCollisionEnter(Collision col)
    {
        if (col.collider.CompareTag(enemyTag))
        {
            col.collider.SendMessageUpwards("AplyDamage", damage);
            DestroyThis();
        }
        else
        {
            DestroyThis();
        }
    }
}
