using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControll : MonoBehaviour
{
    [SerializeField]
    private Transform cameraPos;

    [SerializeField]
    private float speedMove;

    [SerializeField]
    private float speedRotation;

    private Vector3 cameraRotation;
    private bool isCamMoved;

    private void Update()
    {
        MoveCamera();
        RotateCamera();
    }

    private void RotateCamera()
    {
        if (Input.GetMouseButton(1))
        {
            cameraRotation.y += Input.GetAxis("Mouse X") * speedRotation;
        }

        this.transform.eulerAngles = cameraRotation;
    }

    private void MoveCamera()
    {
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S))
        {
            isCamMoved = true;

            if (Input.GetKey(KeyCode.D))
            {
                this.transform.Translate(Vector3.right * speedMove * Time.deltaTime);
            }
            else if (Input.GetKey(KeyCode.A))
            {
                this.transform.Translate(-Vector3.right * speedMove * Time.deltaTime);
            }

            if (Input.GetKey(KeyCode.W))
            {
                this.transform.Translate(Vector3.forward * speedMove * Time.deltaTime);
            }
            else if (Input.GetKey(KeyCode.S))
            {
                this.transform.Translate(-Vector3.forward * speedMove * Time.deltaTime);
            }
        }
        else if (isCamMoved == false)
        {
            this.transform.position = FiguresController.curFigurPosition;
        }
        else if (Input.GetKey(KeyCode.Space))
        {
            isCamMoved = false;
        }
    }
}
