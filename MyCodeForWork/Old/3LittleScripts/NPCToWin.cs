using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCToWin : MonoBehaviour
{
    void Update()
    {
        GetComponent<UnityEngine.UI.Text>().text = PlayerSystematic.npcToWinPlayerMove.ToString();
    }
}
