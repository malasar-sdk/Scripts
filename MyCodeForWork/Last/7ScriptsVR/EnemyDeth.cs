using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeth : MonoBehaviour
{
    [SerializeField]
    private GameObject regDoll;

    public void CreateDoll(GameObject fromEnemy)
    {
        if (fromEnemy != null)
        {
            GameObject go = Instantiate(regDoll, fromEnemy.transform.position, fromEnemy.transform.rotation);

            Destroy(go, 5);
            Destroy(fromEnemy);
        }
    }
}
