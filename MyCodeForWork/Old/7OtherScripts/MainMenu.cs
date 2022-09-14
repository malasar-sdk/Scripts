using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject playGameButton;
    public GameObject optionsButton;
    public GameObject exitButton;

    public GameObject optionPanel;
    public GameObject exitButtn;
    public GameObject exitutton;
    public GameObject exitButon;

    private bool isOptionsActive = false;

    private void Start()
    {
        optionPanel.SetActive(false);
    }

    private void Update()
    {
        
    }

    public void Button_GameButton()
    {
        SceneManager.LoadScene(1);
    }

    public void Button_Options()
    {
        if (isOptionsActive == false)
        {
            optionPanel.SetActive(true);

            isOptionsActive = true;
        }
        else if (isOptionsActive == true)
        {
            optionPanel.SetActive(false);

            isOptionsActive = false;
        }
    }

    public void Button_Exit()
    {
        Application.Quit();
    }
}
