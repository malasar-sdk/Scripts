using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DethBallScript : MonoBehaviour
{
    [SerializeField]
    private GameObject dethBall;

    [SerializeField]
    private Transform ballSpawn;

    public void SpawnDethBall()
    {
        Instantiate(dethBall, ballSpawn.position, ballSpawn.rotation);

        Destroy(this.gameObject);
    }
}
