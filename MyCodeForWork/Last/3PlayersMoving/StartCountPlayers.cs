using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartCountPlayers : MonoBehaviour
{
    [SerializeField]
    private Transform[] startPositions;

    [SerializeField]
    private GameObject massPlayers;

    [SerializeField]
    private GameObject[] players;

    public int numPlayers;

    private void Awake()
    {
        players = new GameObject[numPlayers];

        for (int i = 0; i < numPlayers; i++)
        {
            players[i] = massPlayers.transform.GetChild(i).gameObject;

            players[i].transform.position = startPositions[i].position;
        }
    }
}
