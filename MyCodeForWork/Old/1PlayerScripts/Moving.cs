using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving : MonoBehaviour
{
    [SerializeField] private float speedMove;
    [SerializeField] private float speedRotate;

    void Update()
    {
        PlayerMoving();
    }

    private void PlayerMoving()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * speedMove * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(-Vector3.forward * speedMove * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.D))
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                transform.Translate(Vector3.right * speedMove * Time.deltaTime);
            }
            else
            {
                transform.Rotate(Vector3.up, speedRotate * Time.deltaTime);
            }
        }
        else if (Input.GetKey(KeyCode.A))
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                transform.Translate(-Vector3.right * speedMove * Time.deltaTime);
            }
            else
            {
                transform.Rotate(Vector3.up, -speedRotate * Time.deltaTime);
            }
        }
    }
}
