using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    public Transform targetForCamera;
    public Vector3 offset;

    [SerializeField]
    public float zoomSpeed = 4f;
    [SerializeField]
    public float minZoom = 2f;
    [SerializeField]
    public float maxZoom = 4f;

    [SerializeField]
    public float pitch = 0.1f;

    [SerializeField]
    public float currentZoom = 10f;

    void Update()
    {
        currentZoom -= Input.GetAxis("Mouse ScrollWheel") * zoomSpeed;
        currentZoom = Mathf.Clamp(currentZoom, minZoom, maxZoom);

        transform.position = targetForCamera.position - offset * currentZoom;
        transform.LookAt(targetForCamera.position + Vector3.up * pitch);
    }
}
