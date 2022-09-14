using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinText : MonoBehaviour
{
    void Update()
    {
        GetComponent<UnityEngine.UI.Text>().text = Coin.coin.ToString();
    }
}
