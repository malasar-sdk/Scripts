using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeth : MonoBehaviour
{
    [SerializeField]
    private GameObject regDoll;

    [SerializeField]
    private GameManager gameManager;

    public void CreateRegDoll(GameObject fromEnemy)
    {
        if (fromEnemy != null)
        {
            GameObject reg = Instantiate(regDoll, fromEnemy.transform.position, fromEnemy.transform.rotation);

            gameManager.ScoreUpdate();

            Destroy(reg, 4);
            Destroy(fromEnemy);
        }
    }
}
