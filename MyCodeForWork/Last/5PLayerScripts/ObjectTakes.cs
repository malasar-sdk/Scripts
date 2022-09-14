using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectTakes : MonoBehaviour
{
    [SerializeField]
    private GameObject[] backBlocks;

    [SerializeField]
    private GameObject block;

    [SerializeField]
    private Transform ambarPoint;

    [SerializeField]
    private float blockSpeed;

    [SerializeField]
    private float timingClearing;

    private float timing;

    private int backBlockCount;

    private bool isClearing;

    private void Start()
    {
        block.SetActive(false);

        backBlockCount = 0;

        timing = timingClearing;

        for (int i = 0; i < backBlocks.Length; i++)
        {
            backBlocks[i].gameObject.SetActive(false);
        }
    }

    private void BackClearByOne()
    {
        if (backBlockCount > 0)
        {
            if (timing == 0)
            {
                backBlocks[backBlockCount - 1].gameObject.SetActive(false);
                GameManager.resoursesCount--;
                backBlockCount--;

                GameManager.goldCount += 15;

                timing = timingClearing;
            }
            else
            {
                timing--;
            }

            isClearing = true;
        }
        else
        {
            isClearing = false;

            block.SetActive(false);
        }
    }

    private void LittleBlockSpawn()
    {
        block.transform.position = Vector3.MoveTowards(block.transform.position, ambarPoint.position, Time.deltaTime * blockSpeed);

        if (Vector3.Distance(block.transform.position, ambarPoint.position) < 0.2)
        {
            block.SetActive(false);

            block.transform.position = backBlocks[0].transform.position;
            block.SetActive(true);
            block.transform.position = Vector3.MoveTowards(block.transform.position, ambarPoint.position, Time.deltaTime * blockSpeed);
        }
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.tag == "KolosBlock")
        {
            if (backBlockCount < 40)
            {
                Destroy(col.gameObject);

                backBlocks[backBlockCount].gameObject.SetActive(true);
                backBlockCount++;
                
                GameManager.resoursesCount++;
            }
        }

        if (col.tag == "Ambar")
        {
            block.transform.position = backBlocks[0].transform.position;
            block.SetActive(true);
        }
    }

    private void OnTriggerStay(Collider col)
    {
        if (col.tag == "Ambar")
        {
            BackClearByOne();

            if (isClearing == true)
            {
                LittleBlockSpawn();
            }
        }
    }
}
