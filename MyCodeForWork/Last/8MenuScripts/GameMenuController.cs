using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMenuController : MonoBehaviour
{
    [SerializeField]
    private GameObject menu;

    [SerializeField]
    private GameObject playerInfo;

    private bool isMenuActive;
    private bool isInfoActive;

    private void Start()
    {
        menu.SetActive(false);
        playerInfo.SetActive(false);
    }

    private void Update()
    {
        OpenGameWindows();
    }

    private void OpenGameWindows()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isMenuActive == false)
            {
                menu.SetActive(true);
                isMenuActive = true;

                playerInfo.SetActive(false);
                isInfoActive = false;
            }
            else
            {
                menu.SetActive(false);
                isMenuActive = false;
            }
        }

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (isInfoActive == false)
            {
                playerInfo.SetActive(true);
                isInfoActive = true;

                menu.SetActive(false);
                isMenuActive = false;
            }
            else
            {
                playerInfo.SetActive(false);
                isInfoActive = false;
            }
        }
    }
}
