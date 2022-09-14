using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject pnlMenu;

    [SerializeField]
    private GameObject btnGameMenu;

    private void Start()
    {
        btnGameMenu.SetActive(true);
        pnlMenu.SetActive(false);
    }

    public void ContinueGame()
    {
        pnlMenu.SetActive(false);
        btnGameMenu.SetActive(true);
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void OprnGameMenu()
    {
        pnlMenu.SetActive(true);
        btnGameMenu.SetActive(false);
    }
}
