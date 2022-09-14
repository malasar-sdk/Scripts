using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    void Update()
    {
        GetComponent<UnityEngine.UI.Text>().text = PlayerSystematic.levelPlayerMove.ToString();
    }
}
