using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMovement : MonoBehaviour
{
    NavMeshAgent agent;

    [SerializeField] private float rotationSpeedMovement = 0.075f;
    private float _rotateVelocity;

    private bool _isRun;

    private void Start()
    {
        agent = gameObject.GetComponent<NavMeshAgent>();

        _isRun = false;
    }

    private void Update()
    {
        Movement();
    }

    private void Movement()
    {
        if (Input.GetMouseButton(1))
        {
            RaycastHit hit;

            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, Mathf.Infinity))
            {
                agent.SetDestination(hit.point);

                Quaternion rotatiomToLook = Quaternion.LookRotation(hit.point - transform.position);
                float rotationY = Mathf.SmoothDampAngle(transform.eulerAngles.y, rotatiomToLook.eulerAngles.y, ref _rotateVelocity, rotationSpeedMovement * (Time.deltaTime * 5));

                transform.eulerAngles = new Vector3(0, rotationY, 0);
            }
        }
    }
}
