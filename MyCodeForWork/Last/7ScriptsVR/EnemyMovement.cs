using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField]
    private NavMeshAgent agent;

    [SerializeField]
    private Animator anim;

    [SerializeField]
    private float delay;

    private float _savedTime;

    private Transform playerTarget;

    private void Update()
    {
        if (playerTarget == null)
        {
            FindPlayer();
        }
        else
        {
            if (agent != null)
            {
                agent.SetDestination(playerTarget.position);

                Animation();
            }
        }
    }

    private void FindPlayer()
    {
        playerTarget = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Animation()
    {
        anim.SetFloat("Speed", agent.velocity.magnitude);

        if (_savedTime <= Time.time)
        {
            if (Vector3.Distance(transform.position, playerTarget.position) < agent.stoppingDistance + 0.05f)
            {
                anim.SetTrigger("Attack");

                _savedTime = Time.time + delay;
            }
        }
    }
}
