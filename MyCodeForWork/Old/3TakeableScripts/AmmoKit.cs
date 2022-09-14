using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoKit : MonoBehaviour
{
    [SerializeField] public int ammoKit = 10;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            PlayerSystematic.ammoPlayerMove += ammoKit;
            Destroy(gameObject);
        }
    }
}
