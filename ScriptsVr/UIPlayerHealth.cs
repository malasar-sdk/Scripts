using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIPlayerHealth : MonoBehaviour
{
    [SerializeField]
    private TMP_Text healthTxt;

    [SerializeField]
    private Health health;

    private void Update()
    {
        healthTxt.text = health.GetHealth().ToString();
    }
}
