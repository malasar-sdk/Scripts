using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Shop : MonoBehaviour
{
    [SerializeField]
    private int damage, damageUpCount;

    [SerializeField]
    private float attackSpeed, attackSpeedUpCount;

    [SerializeField]
    private TMP_Text txtDamage, txtAttackSpeed;

    [SerializeField]
    private Economy economy;

    public static int curMoney;

    private void Start()
    {
        damage = 2;
        txtDamage.text = $"Damage: {damage}";
        BulletDamage.damage = damage;

        attackSpeed = 2;
        txtAttackSpeed.text = $"AttackSpeed: {attackSpeed}";
        PlayerShooting.maxAttackSpeed = attackSpeed;
    }

    public void DamageCounChange()
    {
        if (curMoney >= 3)
        {
            damage += damageUpCount;
            txtDamage.text = $"Damage: {damage}";
            BulletDamage.damage = damage;

            curMoney -= 3;
            Economy.moneyUpdate = curMoney;
            economy.MoneyUpdate();
        }
    }

    public void AttackSpeedCounChange()
    {
        if (curMoney >= 3)
        {
            attackSpeed -= attackSpeedUpCount;
            txtAttackSpeed.text = $"AttackSpeed: {attackSpeed}";
            PlayerShooting.maxAttackSpeed = attackSpeed;

            curMoney -= 3;
            Economy.moneyUpdate = curMoney;
            economy.MoneyUpdate();
        }
    }
}
