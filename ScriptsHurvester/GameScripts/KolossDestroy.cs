using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KolossDestroy : MonoBehaviour
{
    [SerializeField]
    private GameObject kolosBlock;

    private void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Kosa")
        {
            Destroy(gameObject);

            Instantiate(kolosBlock, gameObject.transform.position, Quaternion.identity);
        }
    }
}
