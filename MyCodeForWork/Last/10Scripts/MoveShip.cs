using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveShip : MonoBehaviour
{
    [SerializeField]
    private GameObject parentLeft;

    [SerializeField]
    private GameObject parentMiddle;

    [SerializeField]
    private GameObject parentRight;

    [SerializeField]
    private GameObject[] lineLeft;

    [SerializeField]
    private GameObject[] lineMiddle;

    [SerializeField]
    private GameObject[] lineRight;

    [SerializeField][Range(0.5f, 1.5f)]
    private float speedShip;

    [SerializeField]
    [Range(0.1f, 4f)]
    private float speedRotate;

    [SerializeField][Range(0, 2)]
    private int player1, player2;

    [SerializeField]
    private int lineNum;

    [SerializeField]
    private int pointNum;

    private int massCount;

    private bool isPosGot;
    private bool isLineChanged;
    private bool isChangingLocked;
    
    private Vector3 nextPoointPos;
    private Vector3 moveVector;

    private void Start()
    {
        massCount = 0;
        pointNum = 1;
        lineNum = player1;

        isPosGot = true;

        MassivesFill();
        PlayerStart(player1, player2);
    }

    private void Update()
    {
        ChangePosition();
        ChangeSpeed();

        if (isPosGot == true)
        {
            GetPosition(lineNum);
            isPosGot = false;
        }

        MoveLine();
    }

    private void MoveLine()
    {
        moveVector = nextPoointPos - transform.position;

        if (isLineChanged == false)
        {
            if (moveVector.magnitude > 0.05)
            {
                transform.position = Vector3.MoveTowards(transform.position, nextPoointPos, speedShip * Time.deltaTime);

                Vector3 dir = Vector3.RotateTowards(transform.forward, moveVector, speedRotate, 0.0f);
                transform.rotation = Quaternion.LookRotation(dir);
            }
            else
            {
                if (pointNum < massCount - 1)
                {
                    pointNum++;
                }
                else
                {
                    pointNum = 0;
                }

                isPosGot = true;
            }
        }
        else
        {
            if (moveVector.magnitude > 0.05)
            {
                isChangingLocked = true;

                transform.position = Vector3.MoveTowards(transform.position, nextPoointPos, speedShip * Time.deltaTime);
            }
            else
            {
                pointNum++;
                isPosGot = true;
                isLineChanged = false;
                isChangingLocked = false;
            }
        }
    }

    private void GetPosition(int num)
    {
        switch (num)
        {
            case 0:
                nextPoointPos = lineLeft[pointNum].transform.position;
                break;
            case 1:
                nextPoointPos = lineMiddle[pointNum].transform.position;
                break;
            case 2:
                nextPoointPos = lineRight[pointNum].transform.position;
                break;
        }
    }

    private void ChangePosition()
    {
        if (isChangingLocked == false)
        {
            if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
            {
                if (lineNum < 2)
                {
                    lineNum++;
                    isLineChanged = true;
                }
            }
            else if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
            {
                if (lineNum > 0)
                {
                    lineNum--;
                    isLineChanged = true;
                }
            }
        }
    }

    private void ChangeSpeed()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
        {
            if (speedShip < 1.5f)
            {
                speedShip += 0.1f;
            }
            else
            {
                speedShip = 1.5f;
            }
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
        {
            if (speedShip > 0.5f)
            {
                speedShip -= 0.1f;
            }
            else
            {
                speedShip = 0.5f;
            }
        }
    }

    private void MassivesFill()
    {
        massCount = parentLeft.transform.childCount;

        lineLeft = new GameObject[massCount];

        for (int i = 0; i < massCount; i++)
        {
            lineLeft[i] = parentLeft.transform.GetChild(i).gameObject;
        }
        
        massCount = parentMiddle.transform.childCount;

        lineMiddle = new GameObject[massCount];

        for (int i = 0; i < massCount; i++)
        {
            lineMiddle[i] = parentMiddle.transform.GetChild(i).gameObject;
        }
        
        massCount = parentRight.transform.childCount;

        lineRight = new GameObject[massCount];

        for (int i = 0; i < massCount; i++)
        {
            lineRight[i] = parentRight.transform.GetChild(i).gameObject;
        }
    }

    private void PlayerStart(int numPlayer1, int numPlayer2)
    {
        if (numPlayer1 == numPlayer2)
        {
            if (numPlayer1 == 0 || numPlayer1 == 2)
            {
                numPlayer2 = 1;
            }
            else if (numPlayer1 == 1)
            {
                numPlayer2 = 1;
            }
        }

        switch (numPlayer1)
        {
            case 0:
                transform.position = lineLeft[0].transform.position;
                break;
            case 1:
                transform.position = lineMiddle[0].transform.position;
                break;
            case 2:
                transform.position = lineRight[0].transform.position;
                break;
        }
    }
}
