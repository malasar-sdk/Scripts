using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineWay : MonoBehaviour
{
    private LineRenderer lineRenderer;
    private Transform[] wayPoints;

    private void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    public void SetLine(Transform[] points)
    {
        lineRenderer.positionCount = points.Length;
        this.wayPoints = points;
    }

    private void Update()
    {
        for (int i = 0; i < wayPoints.Length; i++)
        {
            lineRenderer.SetPosition(i, wayPoints[i].position);
        }
    }
}
