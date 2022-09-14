using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MedKit : MonoBehaviour
{
    [SerializeField] public int medKit = 20;
    public AudioSource medKitSound;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            PlayerSystematic.healthPlayerMove += medKit;
            Destroy(gameObject);
            medKitSound.Play();
        }
    }
}
