using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingObjects : MonoBehaviour
{
    [SerializeField]
    private float timeDelay;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Gate")
        {
            DestroyObject();
        }
        else if (other.tag == "Player")
        {
            Invoke("DestroyObject", timeDelay);
        }
    }

    private void DestroyObject()
    {
        Destroy(this.gameObject);
    }
}
