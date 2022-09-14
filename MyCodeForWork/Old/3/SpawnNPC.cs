using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class SpawnNPC : MonoBehaviour
{
    [SerializeField] public GameObject npc;
    [SerializeField] public Transform placeSpawn;
    [SerializeField] public float CDTime = 20f;

    void Start()
    {
        StartCoroutine(SpawnCD());
    }

    void Repeat()
    {
        StartCoroutine(SpawnCD());
    }

    IEnumerator SpawnCD()
    {
        Instantiate(npc, placeSpawn.position, Quaternion.identity);
        yield return new WaitForSeconds(CDTime);
        Repeat();
    }
}
