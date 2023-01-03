using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineMoving : MonoBehaviour
{
    [SerializeField] private GameObject lineXVector;
    [SerializeField] private GameObject lineYVector;
    
    [SerializeField] private GameObject lineXLine;
    [SerializeField] private GameObject lineYLine;

    [SerializeField] private float speed;

    public Vector3 koeffX;
    public Vector3 koeffY;

    private Vector3 mousePosition;
    private Vector3 koeffVector;

    void Update()
    {
        if (Input.GetKey(KeyCode.X))
        {
            MoveTo(lineXVector);
            koeffX = koeffVector;

            lineXLine.transform.position = koeffX * 100;

            PoinPlacing.pointKoeffX = koeffX;
        }
        else if (Input.GetKey(KeyCode.Y))
        {
            MoveTo(lineYVector);
            koeffY = koeffVector;

            lineYLine.transform.position = koeffY * 100;

            PoinPlacing.pointKoeffY = koeffY;
        }
    }

    private void MoveTo(GameObject obj)
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z));
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                obj.transform.position = hit.point;

                koeffVector = hit.point;
            }
        }
    }
}
