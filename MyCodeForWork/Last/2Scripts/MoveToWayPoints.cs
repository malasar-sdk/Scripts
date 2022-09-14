using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToWayPoints : MonoBehaviour
{
    [SerializeField] public float Speed;
    [SerializeField] public Transform[] waypoints;
    public GameObject hp;

    int curWaypointIndex = 0;
    
    void Update()
    {
        if (curWaypointIndex < waypoints.Length)
        {
            transform.position = Vector3.MoveTowards(transform.position, waypoints[curWaypointIndex].position, Time.deltaTime * Speed);
            transform.LookAt(waypoints[curWaypointIndex].position);
            if (Vector3.Distance(transform.position, waypoints[curWaypointIndex].position) < 0.5f)
            {
                curWaypointIndex++;
            }
        }

        if (hp.GetComponent<HpBug>().CurHp <= 0)
        {
            Destroy(gameObject);
            Destroy(hp);
        }
    }
}
