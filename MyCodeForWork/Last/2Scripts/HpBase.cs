using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpBase : MonoBehaviour
{
    public int HP = 100;
    public Text HPtext;

    void Update()
    {
        HPtext.text = HP.ToString();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("enemyBug"))
        {
            HP -= 10;
            Destroy(other.gameObject);
            Destroy(other.GetComponent<MoveToWayPoints>().hp);
        }
    }
}
