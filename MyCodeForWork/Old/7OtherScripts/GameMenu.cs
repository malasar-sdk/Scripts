using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameMenu : MonoBehaviour
{
    public GameObject gameMenuCanvas;

    public GameObject continueButton;
    public GameObject optionsButton;
    public GameObject exitButton;

    private bool isOnGameMenu = false;

    private void Update()
    {
        EnterGameMenu();
    }

    public void EnterGameMenu()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && isOnGameMenu == false)
        {
            isOnGameMenu = true;

            gameMenuCanvas.SetActive(true);
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && isOnGameMenu == true)
        {
            isOnGameMenu = false;

            gameMenuCanvas.SetActive(false);
        }
    }

    public void Button_Continue()
    {
        gameMenuCanvas.SetActive(false);
        isOnGameMenu = false;
    }

    public void Button_Options()
    {

    }

    public void Button_Exit()
    {
        Application.Quit();
    }
}
