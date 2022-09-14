using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject gryada;

    [SerializeField]
    private Transform[] spawnsGryadky;

    [SerializeField][Range(0, 15)]
    private int countSpawns;

    [SerializeField]
    private TextMeshProUGUI resoursesText;

    [SerializeField]
    private TextMeshProUGUI goldText;

    public static int resoursesCount;
    public static int goldCount;

    private void Start()
    {
        for (int i = 0; i < countSpawns; i++)
        {
            Instantiate(gryada, spawnsGryadky[i].transform.position, Quaternion.identity);
        }

        resoursesCount = 0;
        resoursesText.text = $"{resoursesCount} / 40";

        goldCount = 0;
        goldText.text = $"{goldCount}";
    }

    private void Update()
    {
        ResoursesCountUpdate();
        GoldCountUpdate();
        GoldUpBying();
    }

    private void ResoursesCountUpdate()
    {
        resoursesText.text = $"{resoursesCount} / 40";
    }

    private void GoldCountUpdate()
    {
        goldText.text = $"{goldCount}";
    }

    public void GoldUpBying()
    {
        goldText.text = $"{goldCount}";
    }
}
