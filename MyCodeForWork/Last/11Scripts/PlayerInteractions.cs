using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractions : MonoBehaviour
{
    [SerializeField]
    private GateController gateController;

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Ball")
        {
            gateController.ScoreUp();

            Debug.Log($"Touched: {col.gameObject.tag}");
        }
        else if (col.gameObject.tag == "Bomb")
        {
            gateController.ScoreDown();

            Debug.Log($"Touched: {col.gameObject.tag}");
        }
        else
        {
            gateController.CoinUp();

            Debug.Log($"Touched: {col.gameObject.tag}");
        }
    }
}
