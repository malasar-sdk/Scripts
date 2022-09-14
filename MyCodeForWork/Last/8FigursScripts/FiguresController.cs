using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FiguresController : MonoBehaviour
{
    [SerializeField]
    private Transform[] playerFigurs;

    [SerializeField]
    private Transform[] spawnPoints;

    [SerializeField]
    private Transform[] pointsFieldsToMove;

    [SerializeField]
    private int[] curNumPosPlayers;

    [SerializeField]
    private float speedFigurs;

    [SerializeField]
    private bool isRoundEnded;

    public static Vector3 curFigurPosition;
    public static bool isRolled;
    public static int numDice;
    public static int howMuchToPlay;

    private int numOfPlayer;

    void Start()
    {
        for (int i = 0; i < howMuchToPlay; i++)
        {
            playerFigurs[i].gameObject.SetActive(true);
            playerFigurs[i].position = spawnPoints[i].position;
        }

        for (int i = 0; i < howMuchToPlay; i++)
        {
            curNumPosPlayers[i] = 0;
        }

        numOfPlayer = 0;
        curFigurPosition = playerFigurs[numOfPlayer].position;
    }
    
    void Update()
    {
        if (isRoundEnded == true)
        {
            numOfPlayer++;

            if (numOfPlayer > howMuchToPlay - 1)
                numOfPlayer = 0;

            isRoundEnded = false;
            DiceRoll.isBtnActive = true;
        }

        PlayerMoving(numOfPlayer);
    }

    public void EndRound()
    {
        isRoundEnded = true;
    }

    private void PlayerMoving(int numPlayer)
    {
        if (isRolled == true)
        {
            int num = numDice;

            if (numDice > 0)
            {
                Vector3 vector = pointsFieldsToMove[curNumPosPlayers[numPlayer] + 1].position - playerFigurs[numOfPlayer].position;
                playerFigurs[numOfPlayer].position += vector.normalized * speedFigurs * Time.deltaTime;

                if (Vector3.Distance(playerFigurs[numOfPlayer].position, pointsFieldsToMove[curNumPosPlayers[numPlayer] + 1].position) < 0.2f)
                {
                    numDice--;
                    if (curNumPosPlayers[numPlayer] >= 38)
                    {
                        curNumPosPlayers[numPlayer] = -1;
                    }
                    else
                    {
                        curNumPosPlayers[numPlayer]++;
                    }
                }
            }
            else
            {
                isRolled = false;
            }
        }

        curFigurPosition = playerFigurs[numOfPlayer].position;
    }
}
