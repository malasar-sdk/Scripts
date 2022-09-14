using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMoving : MonoBehaviour
{
    public Transform enemyEye;
    public Transform targetPlayer;
    [SerializeField] [Range(0, 360)] public float viewAngle = 90f;
    [SerializeField] public float viewDistance;
    [SerializeField] public float detectionDistance;
    [SerializeField] public bool isDrawn = false;
    [SerializeField] public float enemySpeed;

    private NavMeshAgent agentEnemy;
    private Transform agentTransform;
    private float rotationSpeed;

    private void Start()
    {
        agentEnemy = GetComponent<NavMeshAgent>();
        agentEnemy.updateRotation = false;
        rotationSpeed = agentEnemy.angularSpeed;
        agentTransform = agentEnemy.transform;
    }

    private void Update()
    {
        float distanceToPlayer = Vector3.Distance(targetPlayer.transform.position, agentEnemy.transform.position);

        if (distanceToPlayer <= detectionDistance || IsInView())
        {
            RotateToTarget();
            MoveToTarget();
        }

        if (isDrawn == true)
        {
            DrawViewState();
        }
    }

    private bool IsInView()
    {
        float realAngle = Vector3.Angle(enemyEye.forward, targetPlayer.position - enemyEye.position);
        RaycastHit hit;

        if (Physics.Raycast(enemyEye.transform.position, targetPlayer.position - enemyEye.position, out hit, viewDistance))
        {
            if (realAngle < viewAngle / 2f && Vector3.Distance(enemyEye.position, targetPlayer.position) <= viewDistance && hit.transform == targetPlayer.transform)
            {
                return true;
            }
        }

        return false;
    }

    private void RotateToTarget()
    {
        Vector3 lookVector = targetPlayer.position - agentTransform.position;
        lookVector.y = 0;

        if (lookVector == Vector3.zero) return;

        agentTransform.rotation = Quaternion.RotateTowards(agentTransform.rotation, Quaternion.LookRotation(lookVector, Vector3.up), rotationSpeed * Time.deltaTime);
    }

    private void MoveToTarget()
    {
        //agentEnemy.SetDestination(targetPlayer.position);

        transform.position = Vector3.MoveTowards(transform.position, targetPlayer.position, enemySpeed);
    }

    private void DrawViewState()
    {
        Vector3 left = enemyEye.position + Quaternion.Euler(new Vector3(0, viewAngle / 2f, 0)) * (enemyEye.forward * viewDistance);
        Vector3 right = enemyEye.position + Quaternion.Euler(-new Vector3(0, viewAngle / 2f, 0)) * (enemyEye.forward * viewDistance);
        Vector3 forward = enemyEye.position + Quaternion.Euler(new Vector3(0, 0, 0)) * (enemyEye.forward * viewDistance);

        Debug.DrawLine(enemyEye.position, left, Color.red);
        Debug.DrawLine(enemyEye.position, right, Color.red);
        Debug.DrawLine(enemyEye.position, forward, Color.red);
    }
}
