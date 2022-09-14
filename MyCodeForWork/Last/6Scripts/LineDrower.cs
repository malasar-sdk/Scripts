using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineDrower : MonoBehaviour
{
    private LineRenderer _lineRenderer;

    [SerializeField] private Transform[] linePoints;

    void Start()
    {
        _lineRenderer = GetComponent<LineRenderer>();
    }

    void Update()
    {
        Drowing();
    }

    private void Drowing()
    {
        _lineRenderer.positionCount = linePoints.Length;
        for (int i = 0; i < linePoints.Length; i++)
        {
            _lineRenderer.SetPosition(i, linePoints[i].position);
        }
    }
}
