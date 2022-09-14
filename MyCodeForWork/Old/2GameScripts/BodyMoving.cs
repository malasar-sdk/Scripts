using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyMoving : MonoBehaviour
{
    [SerializeField]
    private GameObject head;

    [SerializeField]
    private GameObject body;

    [SerializeField]
    private float speedTail;

    [SerializeField]
    private int count;

    [SerializeField]
    private bool isBodyAdded;

    [SerializeField]
    private float distance;

    [SerializeField]
    private GameObject[] bodyObjects;

    private Vector3 distanceVector;

    private void Start()
    {
        count = 1;

        bodyObjects[0] = head;
    }

    private void Update()
    {
        BodyAdding();
        TailMoving();
    }

    private void BodyAdding()
    {
        if (isBodyAdded == true)
        {
            bodyObjects[count] = Instantiate(body, bodyObjects[count - 1].transform.position, Quaternion.identity);

            count++;
            isBodyAdded = false;
        }
    }

    private void TailMoving()
    {
        for (int i = 1; i < bodyObjects.Length; i++)
        {
            if (bodyObjects[i].gameObject != null)
            {
                distanceVector = bodyObjects[i].transform.position - bodyObjects[i - 1].transform.position;

                if (distanceVector.magnitude > distance)
                {
                    bodyObjects[i].transform.position = Vector3.MoveTowards(bodyObjects[i].transform.position, bodyObjects[i - 1].transform.position, Time.deltaTime * speedTail);
                }
            }
        }
    }

    public void SetAddingBool()
    {
        isBodyAdded = true;
    }
}
