using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFly : MonoBehaviour
{
    [SerializeField]
    private Transform bullet;

    [SerializeField]
    private float speedBullet;

    private Rigidbody rb;
    private Vector3 direction;

    void Start()
    {
        rb = this.GetComponent<Rigidbody>();

        direction = bullet.forward * speedBullet;
        rb.AddForce(direction, ForceMode.VelocityChange);
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Objects")
        {
            ReflectProjectile(rb, col.contacts[0].normal);
        }
        else if (col.gameObject.tag == "Walls")
        {
            Destroy(this.gameObject);
        }
        else if (col.gameObject.tag == "Enemy")
        {
            ScoreManager.scorePlayer += 1;

            Destroy(this.gameObject);

            ScoreManager.isScoreUp = true;
        }
        else if (col.gameObject.tag == "Player")
        {
            ScoreManager.scoreEnemy += 1;

            Destroy(this.gameObject);

            ScoreManager.isScoreUp = true;
        }
    }

    private void ReflectProjectile(Rigidbody rb, Vector3 reflectVector)
    {
        direction = Vector3.Reflect(direction, reflectVector);
        rb.velocity = direction;
    }
}
