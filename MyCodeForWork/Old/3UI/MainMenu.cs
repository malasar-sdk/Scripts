using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Button start;
    [SerializeField] private Button options;
    [SerializeField] private Button exit;
    [SerializeField] private Button back;

    [SerializeField] private Toggle muteSound;
    [SerializeField] private Slider valumeSound;
    [SerializeField] private Dropdown Resolution;

    private void Awake()
    {
        start.onClick.AddListener(StartGame);
        options.onClick.AddListener(Options);
        exit.onClick.AddListener(ExitGame);
        back.onClick.AddListener(BackToMain);

        muteSound.onValueChanged.AddListener(SetMuteSound);
        valumeSound.onValueChanged.AddListener(SetValume);
        valumeSound.value = valumeSound.maxValue * 0.5f;
        Resolution.onValueChanged.AddListener(SetResolution);
    }

    private void StartGame()
    {
        SceneManager.LoadScene(1);

        if (Time.timeScale == 0)
        {
            Time.timeScale = 1;
        }
    }

    private void Options()
    {
        
    }

    private void ExitGame()
    {
        Application.Quit();
    }

    private void BackToMain()
    {

    }

    private void SetMuteSound(bool isMute)
    {

    }

    private void SetValume(float valume)
    {
        int voice = (int)valume;
    }

    private void SetResolution(int resol)
    {

    }
}
