using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerAtack : MonoBehaviour
{
    [SerializeField]
    private GameObject kosa;

    [SerializeField]
    private TextMeshProUGUI txtButton;

    private Animator animator;

    public static bool attacking;

    private void Start()
    {
        animator = GetComponent<Animator>();

        kosa.SetActive(false);

        txtButton.text = $"Attack OFF";
    }

    private void Update()
    {
        Atacking();
    }

    public void BoolChangeAttack()
    {
        if (attacking == true)
        {
            attacking = false;
        }
        else
        {
            attacking = true;
        }
    }

    private void Atacking()
    {
        if (attacking == true)
        {
            kosa.SetActive(true);
            animator.SetBool("IsAtack", true);

            txtButton.text = $"Attack ON";
        }
        else
        {
            kosa.SetActive(false);
            animator.SetBool("IsAtack", false);

            txtButton.text = $"Attack OFF";
        }
    }
}
