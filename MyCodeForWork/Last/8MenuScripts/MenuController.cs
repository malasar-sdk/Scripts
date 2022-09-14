using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    [SerializeField]
    private int playersCount;

    [SerializeField]
    private TextMeshProUGUI textPlayersCount;

    [SerializeField]
    private GameObject optionsPanel;

    private bool isOptionsOpen;

    private void Start()
    {
        playersCount = 3;
        textPlayersCount.text = $"{playersCount}";

        optionsPanel.SetActive(false);
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void Options()
    {
        if (isOptionsOpen == false)
        {
            optionsPanel.SetActive(true);
            isOptionsOpen = true;
        }
        else
        {
            optionsPanel.SetActive(false);
            isOptionsOpen = false;
        }
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void CangeNumPlayersMore()
    {
        if (playersCount < 4)
        {
            playersCount++;
            textPlayersCount.text = $"{playersCount}";

            FiguresController.howMuchToPlay = playersCount;
        }
    }

    public void CangeNumPlayersLess()
    {
        if (playersCount > 1)
        {
            playersCount--;
            textPlayersCount.text = $"{playersCount}";


            FiguresController.howMuchToPlay = playersCount;
        }
    }
}
