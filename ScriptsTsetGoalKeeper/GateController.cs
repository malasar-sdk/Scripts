using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GateController : MonoBehaviour
{
    [SerializeField]
    private ObjectsShooting objectsShooting1;

    [SerializeField]
    private ObjectsShooting objectsShooting2;

    [SerializeField]
    private GameObject panelGameOver;

    [SerializeField]
    private TextMeshProUGUI scoreText;

    [SerializeField]
    private TextMeshProUGUI coinText;

    [SerializeField]
    private TextMeshProUGUI timeText;

    [SerializeField]
    private Slider scoreSlider;

    [SerializeField]
    private TextMeshProUGUI maxScoreText;

    [SerializeField]
    private int maxScore;

    [SerializeField]
    private int maxScoreStep;

    [SerializeField]
    private int bombDamg;

    [SerializeField]
    private int timeRoundMax;

    private int _score;
    private int _coin;
    private int _time;
    private int _midTime;

    private int timeXXX = 500;

    private bool isTimeEnd;

    private void Start()
    {
        panelGameOver.SetActive(false);

        maxScoreText.text = $"maxScore score: {maxScore}";

        scoreSlider.maxValue = maxScore;
        _score = 0;
        _coin = 0;
        _time = timeRoundMax * timeXXX;

        InfoUpdate();
    }

    private void Update()
    {
        if (isTimeEnd == false)
        {
            Timing();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Ball")
        {
            if (_score > 0)
            {
                _score--;
            }
            else
            {
                _score = 0;
            }

            scoreSlider.value = _score;

            InfoUpdate();
        }
    }

    public void ScoreUp()
    {
        _score++;

        if (_score >= maxScore)
        {
            _score = maxScore;
        }

        scoreSlider.value = _score;

        InfoUpdate();
    }

    public void ScoreDown()
    {
        _score -= bombDamg;

        if (_score <= 0)
        {
            _score = 0;
        }

        InfoUpdate();
    }

    public void CoinUp()
    {
        _coin++;

        InfoUpdate();
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        objectsShooting1.StartShooting();
        objectsShooting2.StartShooting();
    }

    private void InfoUpdate()
    {
        scoreText.text = $"{_score}";
        coinText.text = $"Coins: {_coin}";

        scoreSlider.value = _score;
        maxScoreText.text = $"maxScore score: {maxScore}";
    }

    private void Timing()
    {
        _time--;

        if (_time % timeXXX == 0)
        {
            _midTime = _time / timeXXX;
            timeText.text = $"{_midTime}";
        }

        if (_time <= 0 && _score < maxScore)
        {
            panelGameOver.SetActive(true);
            isTimeEnd = true;

            Time.timeScale = 0;
        }
        else if (_time <= 0 && _score >= maxScore)
        {
            _score = 0;
            maxScore += maxScoreStep;
            timeRoundMax += 5;
            scoreSlider.maxValue = maxScore;
            _time = timeRoundMax * timeXXX;

            InfoUpdate();
        }
    }
}
