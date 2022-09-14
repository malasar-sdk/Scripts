using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputTargeting : MonoBehaviour
{
    [SerializeField] private GameObject selectedHero;
    [SerializeField] private bool heroPlayer;
    RaycastHit hit;

    void Start()
    {
        selectedHero = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        
    }
}
