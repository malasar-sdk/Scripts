using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField]
    private Animator animator;

    private NavMeshAgent agent;
    private Transform target;

    private float _savedTime;
    private float _attackDelay = 2;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        FindTarget();
        Attacking();
    }

    private void FindTarget()
    {
        if (target == null)
        {
            target = GameObject.FindGameObjectWithTag("Player").transform;
        }
        else
        {
            if (agent != null)
            {
                agent.SetDestination(target.position);

                animator.SetFloat("Speed", agent.velocity.magnitude);
            }
        }
    }

    private void Attacking()
    {
        if (_savedTime <= Time.time)
        {
            if (Vector3.Distance(transform.position, target.position) < agent.stoppingDistance + 0.05f)
            {
                animator.SetTrigger("Attack");
                _savedTime = Time.time + _attackDelay;
            }
        }
    }
}
