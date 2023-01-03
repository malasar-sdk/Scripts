using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField]
    private float health;

    [SerializeField]
    private int moneyPlus;

    [SerializeField]
    private GameObject objWithScripts, detector;

    [SerializeField]
    private SpawnHumans spawnHumans;

    [SerializeField]
    private HumansDetection humansDetection;

    [SerializeField]
    private Economy economy;

    private void Update()
    {
        if (objWithScripts == null)
        {
            objWithScripts = GameObject.FindGameObjectWithTag("Scripts");
        }

        if (spawnHumans == null)
        {
            spawnHumans = objWithScripts.GetComponent<SpawnHumans>();
        }

        if (economy == null)
        {
            economy = objWithScripts.GetComponent<Economy>();
        }
    }

    public void AplyDamage(int dmg)
    {
        health -= dmg;

        if (health <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        spawnHumans.WaveUpdate();
        Destroy(gameObject);

        economy.MoneyCounChange(moneyPlus);

        HumansDetection.isDestroyed = true;
    }

    public void SetMaxHealth(int hp)
    {
        health = hp;
    }
}
