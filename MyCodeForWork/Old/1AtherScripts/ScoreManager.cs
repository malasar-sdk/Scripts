using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    [SerializeField]
    private Text txtScorePlayer;

    [SerializeField]
    private Text txtScoreEnemy;

    [SerializeField]
    private Transform playerPref;

    [SerializeField]
    private Transform enemyPref;

    [SerializeField]
    private Transform spawnPlayer;

    [SerializeField]
    private Transform spawnEnemy;

    public static int scorePlayer;
    public static int scoreEnemy;

    public static bool isScoreUp;

    private void Start()
    {
        scorePlayer = 0;
        scoreEnemy = 0;
    }

    private void Update()
    {
        txtScorePlayer.text = $"Player score: {scorePlayer}";

        txtScoreEnemy.text = $"Enemy score: {scoreEnemy}";

        if (isScoreUp == true)
        {
            RespawnPlayers();

            isScoreUp = false;
        }
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void RespawnPlayers()
    {
        playerPref.position = spawnPlayer.position;
        enemyPref.position = spawnEnemy.position;

        playerPref.rotation = spawnPlayer.rotation;
        enemyPref.rotation = spawnEnemy.rotation;
    }
}
