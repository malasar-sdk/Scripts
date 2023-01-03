using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoinPlacing : MonoBehaviour
{
    [SerializeField] private Transform pointToSpawn;

    [SerializeField] private float inputNewX;
    [SerializeField] private float inputNewY;

    public static Vector3 pointKoeffX;
    public static Vector3 pointKoeffY;

    [SerializeField] private float angle;
    [SerializeField] private float angleMiddle;
    [SerializeField] private float cosX;
    [SerializeField] private float newPointLength;

    [SerializeField] private float angleX;

    [SerializeField] private Vector3 newPoint;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            CreatePointVector();
        }
    }

    private void CreatePointVector()
    {
        Vector3 lineX = pointKoeffX * inputNewX;
        Vector3 lineY = pointKoeffY * inputNewY;

        angle = Vector3.Angle(lineX, lineY);

        cosX = (angle * lineX.magnitude) / (lineX.magnitude + lineY.magnitude);
        newPointLength = lineX.magnitude / cosX;
        
        angleMiddle = Mathf.Acos(cosX);
        angleX = Vector3.Angle(Vector3.right, lineX);

        newPoint = new Vector3(newPointLength, 0, 0);
        Instantiate(pointToSpawn, newPoint, Quaternion.identity);

        pointToSpawn.transform.RotateAround(new Vector3(0, 0, 0), newPoint, angleMiddle + angleX);
    }
}
