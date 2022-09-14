using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameMenu : MonoBehaviour
{
    public GameObject gameMenu;
    private bool escapeMenuOpen = false;

    [SerializeField] private Button continueGame;
    [SerializeField] private Button mainMenu;
    [SerializeField] private Button exitGame;

    private void Start()
    {
        continueGame.onClick.AddListener(ContinueGame);
        mainMenu.onClick.AddListener(MainMenu);
        exitGame.onClick.AddListener(ExitGame);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && escapeMenuOpen == false)
        {
            gameMenu.SetActive(true);
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.None;
            escapeMenuOpen = true;
        }

        else if (Input.GetKeyDown(KeyCode.Escape) && escapeMenuOpen == true)
        {
            gameMenu.SetActive(false);
            Time.timeScale = 1;
            Cursor.lockState = CursorLockMode.Locked;
            escapeMenuOpen = false;
        }
    }

    private void ContinueGame()
    {
        Cursor.lockState = CursorLockMode.Locked;
        gameMenu.SetActive(false);
        Time.timeScale = 1;
    }

    private void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

    private void ExitGame()
    {
        Application.Quit();
    }
}
