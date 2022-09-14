using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineTEst : MonoBehaviour
{
    [SerializeField]
    private Transform[] points;

    [SerializeField]
    private Transform parentPoint;

    [SerializeField]
    private LineWay lineWay;

    private int massCount;

    private void Start()
    {
        massCount = parentPoint.transform.childCount;

        points = new Transform[massCount];

        for (int i = 0; i < massCount; i++)
        {
            points[i] = parentPoint.transform.GetChild(i).transform;
        }

        lineWay.SetLine(points);
    }
}
