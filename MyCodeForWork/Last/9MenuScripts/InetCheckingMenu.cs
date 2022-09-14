using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class InetCheckingMenu : MonoBehaviour
{
    [SerializeField]
    private Toggle checkAgree;

    [SerializeField]
    private GameObject pnlCheckingPolicy;

    [SerializeField]
    private GameObject pnlPolicyText;

    private void Start()
    {
        pnlCheckingPolicy.SetActive(true);
        pnlPolicyText.SetActive(false);

        checkAgree.isOn = false;
    }

    public void OpenPolicyText()
    {
        pnlCheckingPolicy.SetActive(false);
        pnlPolicyText.SetActive(true);
    }

    public void ClosePolicyText()
    {
        pnlCheckingPolicy.SetActive(true);
        pnlPolicyText.SetActive(false);
    }

    public void GoNext()
    {
        if (checkAgree.isOn == true)
        {
            SceneManager.LoadScene(1);
        }
    }
}
