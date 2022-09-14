using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowing : MonoBehaviour
{
    [SerializeField] private Transform playerPosition;
    [SerializeField] private Camera cam;
    [SerializeField] private float zoomSpeed;

    private Vector3 cameraOffset;

    private float _camFov;
    private float _mouswScrollInput;

    [Range(0.01f, 1.0f)]
    [SerializeField] float smoothness = 0.5f;

    void Start()
    {
        cameraOffset = transform.position - playerPosition.transform.position;

        _camFov = cam.fieldOfView;
    }

    void Update()
    {
        CameraFollow();
        CameraScroll();
    }

    private void CameraFollow()
    {
        Vector3 newPosition = playerPosition.position + cameraOffset;
        transform.position = Vector3.Slerp(transform.position, newPosition, smoothness);
    }

    private void CameraScroll()
    {
        _mouswScrollInput = Input.GetAxis("Mouse ScrollWheel");

        _camFov -= _mouswScrollInput * zoomSpeed;
        _camFov = Mathf.Clamp(_camFov, 30, 60);

        cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, _camFov, zoomSpeed);
    }
}
