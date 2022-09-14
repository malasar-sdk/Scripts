using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[RequireComponent(typeof(Health))]
public class UIPlayerHealth : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI txtHealth;

    private Health _health;

    private void Awake()
    {
        _health = gameObject.GetComponent<Health>();
    }

    private void Update()
    {
        txtHealth.text = $"Health: {_health.GetHealth().ToString()}";

        if (txtHealth.text == "0")
        {
            GameOver();
        }
    }

    private void GameOver()
    {

    }
}
