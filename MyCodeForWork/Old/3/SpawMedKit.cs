using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawMedKit : MonoBehaviour
{
    [SerializeField] public GameObject medKit;
    [SerializeField] public Transform medKitSpawn;
    [SerializeField] public float CDTimeMedKIt = 30f;

    void Start()
    {
        StartCoroutine(SpawnMedKitCD());
    }

    void Repeat()
    {
        StartCoroutine(SpawnMedKitCD());
    }

    IEnumerator SpawnMedKitCD()
    {
        yield return new WaitForSeconds(CDTimeMedKIt);

        if (medKit != null)
        {
            Destroy(medKit);
        }
        
        Instantiate(medKit, medKitSpawn.position, Quaternion.identity);
        
        Repeat();
    }
}
