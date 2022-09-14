using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Game : MonoBehaviour
{
    [SerializeField]
    private GameObject[] objects;

    [SerializeField]
    private Transform spawnUp;

    [SerializeField]
    private Transform spawnDawn;

    [SerializeField]
    private Transform rayPoint;

    [SerializeField]
    private TextMeshProUGUI txtScore;

    [SerializeField]
    private float spawnDelay;

    private int randNum;
    private int score;

    private bool isPlaced;
    private bool isPLay;
    private bool isChecked;


    void Start()
    {
        score = 10;
        txtScore.text = $"{score}";
    }
    
    void Update()
    {
        CheckCupple();

        if (isPLay == true)
        {
            if (isPlaced == false)
            {
                isPlaced = true;

                StartCoroutine(SpawnObject());
            }
        }
    }

    public void BtnPLayClick()
    {
        isPLay = true;
    }

    private void CheckCupple()
    {
        RaycastHit hitUp;
        RaycastHit hitDown;

        Ray rayUp = new Ray(rayPoint.position, Vector3.forward);
        Ray rayDawn = new Ray(rayPoint.position, -Vector3.forward);

        Physics.Raycast(rayUp, out hitUp);
        Physics.Raycast(rayDawn, out hitDown);

        if (hitUp.collider.gameObject.tag == hitDown.collider.gameObject.tag && hitUp.collider.gameObject.tag != "Border" && hitDown.collider.gameObject.tag != "Border")
        {
            if (isChecked == false)
            {
                score *= 2;
                txtScore.text = $"{score}";

                isChecked = true;
            }
        }

        if (hitUp.collider.gameObject.tag == "Border" && hitDown.collider.gameObject.tag == "Border")
        {
            isChecked = false;
        }
    }

    private IEnumerator SpawnObject()
    {
        randNum = Random.Range(0, 8);
        if (randNum == 0 || randNum == 3 || randNum == 6)
        {
            Instantiate(objects[0], spawnUp.position, spawnUp.transform.rotation);
        }
        else if (randNum == 1 || randNum == 4 || randNum == 7)
        {
            Instantiate(objects[1], spawnUp.position, spawnUp.transform.rotation);
        }
        else if (randNum == 2 || randNum == 5 || randNum == 8)
        {
            Instantiate(objects[2], spawnUp.position, spawnUp.transform.rotation);
        }

        randNum = Random.Range(0, 2);
        if (randNum == 0 || randNum == 3 || randNum == 6)
        {
            Instantiate(objects[0], spawnDawn.position, spawnDawn.transform.rotation);
        }
        else if (randNum == 1 || randNum == 4 || randNum == 7)
        {
            Instantiate(objects[1], spawnDawn.position, spawnDawn.transform.rotation);
        }
        else if (randNum == 2 || randNum == 5 || randNum == 8)
        {
            Instantiate(objects[2], spawnDawn.position, spawnDawn.transform.rotation);
        }

        yield return new WaitForSeconds(spawnDelay);

        isPlaced = false;
    }
}
