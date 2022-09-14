using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealhText : MonoBehaviour
{
    void Update()
    {
        GetComponent<UnityEngine.UI.Text>().text = PlayerSystematic.healthPlayerMove.ToString();
    }
}
