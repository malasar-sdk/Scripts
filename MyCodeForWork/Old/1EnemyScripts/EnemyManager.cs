using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyManager : MonoBehaviour
{
    private NavMeshAgent agent;

    [SerializeField]
    [Range(0, 360)]
    private float viewAngle;

    [SerializeField]
    private float viewDistance;

    [SerializeField]
    private float detectionDistance;

    [SerializeField]
    private Transform enemyEye;

    [SerializeField]
    private Transform targetPlayer;

    [SerializeField]
    private Transform[] movingSpots;

    [SerializeField]
    private Transform spawnBullet;

    [SerializeField]
    private GameObject bullet;

    [SerializeField]
    private float fireRate;

    private float currentFireRate;

    private float rotationSpeed;
    private Transform agentPosition;

    private int randomSpot;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        rotationSpeed = agent.angularSpeed;
        agentPosition = agent.transform;

        randomSpot = Random.Range(0, movingSpots.Length);

        currentFireRate = 0;
    }

    private void Update()
    {
        float distanceToPlayer = Vector3.Distance(targetPlayer.position, agent.transform.position);

        if (distanceToPlayer <= detectionDistance || IsOnView())
        {
            RotateToTarget();
            MoveToTarget();
            Shooting();
        }
        else
        {
            Patrolling();
        }

        DrawViewState();
    }

    private bool IsOnView()
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
        Vector3 lookVector = targetPlayer.position - agentPosition.position;
        lookVector.y = 0;

        if (lookVector == Vector3.zero)
        {
            return;
        }

        agentPosition.rotation = Quaternion.RotateTowards(agentPosition.rotation, Quaternion.LookRotation(lookVector, Vector3.up), rotationSpeed * Time.deltaTime);
    }

    private void MoveToTarget()
    {
        agent.SetDestination(targetPlayer.position);
    }

    private void Patrolling()
    {
        agent.SetDestination(movingSpots[randomSpot].position);
        agent.transform.LookAt(movingSpots[randomSpot].position);

        if (Vector3.Distance(transform.position, movingSpots[randomSpot].position) < 0.4f)
        {
            randomSpot = Random.Range(0, movingSpots.Length);
        }
    }

    private void Shooting()
    {
        RaycastHit hit;

        if (Physics.Raycast(enemyEye.transform.position, enemyEye.transform.forward, out hit, viewDistance) && hit.collider.tag == "Player")
        {
            if (currentFireRate <= 0.1f)
            {
                Instantiate(bullet, spawnBullet.position, spawnBullet.rotation);

                currentFireRate = fireRate;
            }
            else
            {
                currentFireRate -= Time.deltaTime;
            }
        }
    }

    private void DrawViewState()
    {
        Vector3 left = enemyEye.position + Quaternion.Euler(new Vector3(0, viewAngle / 2f, 0)) * (enemyEye.forward * viewDistance);
        Vector3 left2 = enemyEye.position + Quaternion.Euler(new Vector3(0, viewAngle / 4f, 0)) * (enemyEye.forward * viewDistance);
        Vector3 left3 = enemyEye.position + Quaternion.Euler(new Vector3(0, viewAngle / 10f, 0)) * (enemyEye.forward * viewDistance);
        Vector3 right = enemyEye.position + Quaternion.Euler(-new Vector3(0, viewAngle / 2f, 0)) * (enemyEye.forward * viewDistance);
        Vector3 right2 = enemyEye.position + Quaternion.Euler(-new Vector3(0, viewAngle / 4f, 0)) * (enemyEye.forward * viewDistance);
        Vector3 right3 = enemyEye.position + Quaternion.Euler(-new Vector3(0, viewAngle / 10f, 0)) * (enemyEye.forward * viewDistance);

        Debug.DrawLine(enemyEye.position, left, Color.yellow);
        Debug.DrawLine(enemyEye.position, left2, Color.yellow);
        Debug.DrawLine(enemyEye.position, right, Color.yellow);
        Debug.DrawLine(enemyEye.position, right2, Color.yellow);
        Debug.DrawLine(enemyEye.position, left3, Color.yellow);
        Debug.DrawLine(enemyEye.position, right3, Color.yellow);
    }
}
