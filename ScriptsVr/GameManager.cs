using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private int maxScoreToLevelUp, scoreLevelStep;

    [SerializeField]
    private TMP_Text score;

    [SerializeField]
    private TMP_Text level;

    [SerializeField]
    private TMP_Text totalScore;

    [SerializeField]
    private GameObject pnlGameOver;

    [SerializeField]
    private EnemySpawner spawner;

    private int _scoreVol;
    private int _levelVol;

    private void Start()
    {
        pnlGameOver.SetActive(false);

        _scoreVol = 0;
        score.text = $"Score: {_scoreVol}";

        _levelVol = 1;
        level.text = $"Level: {_levelVol}";
    }

    public void GameOverPlayer()
    {
        pnlGameOver.SetActive(true);
        totalScore.text = $"Total score: {_scoreVol}";
    }

    public void ScoreUpdate()
    {
        if (_scoreVol == maxScoreToLevelUp)
        {
            _scoreVol = 0;
            _levelVol++;
            maxScoreToLevelUp += scoreLevelStep;

            spawner.SpawnTimeUpdate();
        }
        else
        {
            _scoreVol++;
        }

        score.text = $"Score: {_scoreVol}";
        level.text = $"Level: {_levelVol}";
    }

    public void RstartGame()
    {
        SceneManager.LoadScene(0);
    }
}
