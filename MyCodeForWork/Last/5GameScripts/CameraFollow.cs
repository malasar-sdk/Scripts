using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]
    private Transform playerPos;

    [SerializeField]
    private Transform cameraPos;

    private void Update()
    {
        cameraPos.position = playerPos.position;
    }
}
