using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public Text txtScore;
    public GameObject btnRestart;
    public GameObject player;

    public bool isGameEnd;

    private int score = 0;

    private void Start()
    {
        isGameEnd = false;
    }

    private void Update()
    {
        score = TakingThings.numNPC;

        txtScore.text = $"{score}";

        if (score >= 5)
        {
            isGameEnd = true;
        }

        if (isGameEnd == true)
        {
            btnRestart.SetActive(true);

            Time.timeScale = 0;
        }
        else
        {
            btnRestart.SetActive(false);

            Time.timeScale = 1;
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
