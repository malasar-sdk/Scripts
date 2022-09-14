using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMoving : MonoBehaviour
{
    [SerializeField] public LayerMask WhatToClic;

    private NavMeshAgent myAgent;

    private void Start()
    {
        myAgent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Ray myRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;

            if (Physics.Raycast(myRay, out hitInfo, 100, WhatToClic))
            {
                myAgent.SetDestination(hitInfo.point);
            }
        }
    }
}
