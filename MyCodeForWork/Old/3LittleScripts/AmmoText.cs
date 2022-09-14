using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoText : MonoBehaviour
{
    void Update()
    {
        GetComponent<UnityEngine.UI.Text>().text = PlayerSystematic.ammoPlayerMove.ToString();
    }
}
