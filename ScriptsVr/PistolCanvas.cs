using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PistolCanvas : MonoBehaviour
{
    [SerializeField]
    private GameObject canvas;

    private void Start()
    {
        canvas.SetActive(false);
    }

    public void SetActive()
    {
        canvas.SetActive(true);
    }

    public void ResetActive()
    {
        canvas.SetActive(false);
    }
}