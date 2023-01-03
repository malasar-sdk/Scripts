using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Economy : MonoBehaviour
{
    [SerializeField]
    private int money;

    [SerializeField]
    private TMP_Text txtMoney;

    public static int moneyUpdate;

    private void Start()
    {
        money = 0;
        txtMoney.text = $"Money: {money}";
        Shop.curMoney = money;
    }

    public void MoneyCounChange(int mon)
    {
        money += mon;
        txtMoney.text = $"Money: {money}";
        Shop.curMoney = money;
    }

    public void MoneyUpdate()
    {
        money = moneyUpdate;

        txtMoney.text = $"Money: {money}";
        Shop.curMoney = money;
    }
}
