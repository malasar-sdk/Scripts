using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField]
    private float speedMove;

    private void Update()
    {
        Moving();
    }

    private void Moving()
    {
        transform.position += transform.forward * speedMove * Time.deltaTime;
    }

    public void TurningUp()
    {
        Vector3 dir = Vector3.RotateTowards(transform.forward, Vector3.forward, 10, 0.0f);

        transform.rotation = Quaternion.LookRotation(dir);
    }

    public void TurningRight()
    {
        Vector3 dir = Vector3.RotateTowards(transform.forward, Vector3.right, 10, 0.0f);

        transform.rotation = Quaternion.LookRotation(dir);
    }

    public void TurningDown()
    {
        Vector3 dir = Vector3.RotateTowards(transform.forward, Vector3.back, 10, 0.0f);

        transform.rotation = Quaternion.LookRotation(dir);
    }

    public void TurningLeft()
    {
        Vector3 dir = Vector3.RotateTowards(transform.forward, Vector3.left, 10, 0.0f);

        transform.rotation = Quaternion.LookRotation(dir);
    }
}
