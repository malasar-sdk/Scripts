using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerAnimator : MonoBehaviour
{
    NavMeshAgent agent;

    [SerializeField] private Animator animator;

    private float _motionSmoothTime = 0.1f;

    void Start()
    {
        agent = gameObject.GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        AnimIdleToRun();
    }

    private void AnimIdleToRun()
    {
        float speed = agent.velocity.magnitude / agent.speed;
        animator.SetFloat("Speed", speed, _motionSmoothTime, Time.deltaTime);
    }
}
