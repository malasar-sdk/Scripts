using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoOridginalText : MonoBehaviour
{
    void Update()
    {
        GetComponent<UnityEngine.UI.Text>().text = ShootGun.ammoOridg.ToString();
    }
}
