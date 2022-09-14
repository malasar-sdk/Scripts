using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpening : MonoBehaviour
{
    [SerializeField]
    private Transform door;

    [SerializeField]
    private Vector3 openValue, closeValue;

    [SerializeField]
    private float speed;

    private bool _isOpened;

    private void Update()
    {
        door.localEulerAngles = Vector3.Lerp(door.localEulerAngles, _isOpened ? openValue : closeValue, Time.deltaTime * speed);
    }

    public void Use()
    {
        _isOpened = !_isOpened;
    }
}
