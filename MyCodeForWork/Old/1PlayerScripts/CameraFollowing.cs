using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowing : MonoBehaviour
{
    [SerializeField] private Transform playerPosition;
    [SerializeField] private float rangeToPlayer;

    void Update()
    {
        transform.position = new Vector3(playerPosition.position.x, rangeToPlayer, playerPosition.position.z);
    }
}
