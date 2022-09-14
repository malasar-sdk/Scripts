using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gryada : MonoBehaviour
{
    [SerializeField]
    private GameObject kolos;

    [SerializeField]
    private Transform[] spawnCrops;

    [SerializeField]
    private float delayGrawing;

    private int count;
    private bool isGryadaClear;

    private float timing;

    private void Start()
    {
        count = 4;

        timing = delayGrawing * 60;

        for (int i = 0; i < spawnCrops.Length; i++)
        {
            Instantiate(kolos, spawnCrops[i].transform.position, Quaternion.identity);
        }
    }

    private void Update()
    {
        CheckingKolos();

        if (isGryadaClear == true)
        {
            GrowCrops();
        }
        else
        {
            GrowCrops();
        }
    }

    public void GrowCrops()
    {
        if (timing == 0f)
        {
            for (int i = 0; i < spawnCrops.Length; i++)
            {
                Instantiate(kolos, spawnCrops[i].transform.position, Quaternion.identity);
            }

            isGryadaClear = false;
            timing = delayGrawing * 60;
        }
        else
        {
            timing--;
        }
    }

    private void CheckingKolos()
    {
        for (int i = 0; i < spawnCrops.Length; i++)
        {
            RaycastHit hit;
            Ray ray = new Ray(spawnCrops[i].position, Vector3.up);

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.tag != "Kolos")
                {
                    count--;
                }
            }
        }

        if (count == 0)
        {
            isGryadaClear = true;
            count = 4;
        }
        else
        {
            count = 4;
        }
    }
}
