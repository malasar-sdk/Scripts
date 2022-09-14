using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPoints : MonoBehaviour
{
    [SerializeField, Header("Первоначальный массив")]
    private GameObject wayPointMass;

    public Transform[] linePlayer1;

    public Transform[] linePlayer2;

    public Transform[] linePlayer3;

    public Transform[] linePlayer4;

    public Transform[] linePlayer5;

    public Transform[] linePlayer6;

    private int _numMainMass;

    private void Awake()
    {
        _numMainMass = 0;

        for (int i = 0; i < 10; i++)
        {
            linePlayer1[i] = wayPointMass.transform.GetChild(_numMainMass).transform;
            _numMainMass++;

            linePlayer2[i] = wayPointMass.transform.GetChild(_numMainMass).transform;
            _numMainMass++;

            linePlayer3[i] = wayPointMass.transform.GetChild(_numMainMass).transform;
            _numMainMass++;

            linePlayer4[i] = wayPointMass.transform.GetChild(_numMainMass).transform;
            _numMainMass++;

            linePlayer5[i] = wayPointMass.transform.GetChild(_numMainMass).transform;
            _numMainMass++;

            linePlayer6[i] = wayPointMass.transform.GetChild(_numMainMass).transform;
            _numMainMass++;
        }
    }
}
