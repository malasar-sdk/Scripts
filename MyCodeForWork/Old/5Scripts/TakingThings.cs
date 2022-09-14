using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakingThings : MonoBehaviour
{
    public static int numNPC = 0;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            Debug.Log("Collision ON");
            numNPC++;

            other.gameObject.SetActive(false);
        }
    }
}
