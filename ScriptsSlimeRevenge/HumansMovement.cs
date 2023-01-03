using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class HumansMovement : MonoBehaviour
{
    [SerializeField]
    private GameObject player;

    [SerializeField]
    private NavMeshAgent agent;

    private void Update()
    {
        CheckingPlayer();

        HumanMoving();
    }

    private void HumanMoving()
    {
        if (player != null)
        {
            agent.SetDestination(player.transform.position);
        }
    }

    private void CheckingPlayer()
    {
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }
    }
}
