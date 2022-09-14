using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpBug : MonoBehaviour
{
    public GameObject enemy;
    
    public int CurHp = 30;

    public void Dmg(int DMGcount)
    {
        CurHp -= DMGcount;
    }

    void Update()
    {
        GetComponent<RectTransform>().position = Camera.main.WorldToScreenPoint(enemy.transform.position);
        GetComponent<Text>().text = CurHp.ToString();
    }
}
