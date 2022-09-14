using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DiceRoll : MonoBehaviour
{
    [SerializeField]
    private Button btnRoll;

    [SerializeField]
    private TextMeshProUGUI txtDice;

    public static bool isBtnActive;

    private int rand;

    private void Start()
    {
        isBtnActive = true;
    }

    private void Update()
    {
        if (isBtnActive == true)
        {
            btnRoll.interactable = true;
            btnRoll.gameObject.SetActive(true);

        }
        else
        {
            btnRoll.interactable = false;
            btnRoll.gameObject.SetActive(false);
        }
    }

    public void Rolling()
    {
        rand = Random.Range(1, 12);

        txtDice.text = $"{rand}";
        isBtnActive = false;
        
        FiguresController.numDice = rand;
        FiguresController.isRolled = true;
    }
}
