using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerSystematic : MonoBehaviour
{
    [SerializeField] public GameObject player;
    [SerializeField] public int healthPlayer = 100;
    [SerializeField] public int ammoPlayer = 40;
    [SerializeField] public int npcToWinPlayer = 20;

    [SerializeField] public Transform playerSpawn;

    public AudioSource takeDamageSoundPlayer;
    public AudioSource dethSoundPlayer;
    public AudioSource PickUpSoundPlayer;

    static public int healthPlayerMove;
    static public int ammoPlayerMove;
    static public int ammoOridginalPlayerMove;
    static public int npcToWinPlayerMove;
    static public int levelPlayerMove = 1;

    void Start()
    {
        healthPlayerMove = healthPlayer;
        ammoPlayerMove = ammoPlayer;
        npcToWinPlayerMove = npcToWinPlayer;
        levelPlayerMove = 1;
    }

    private void Update()
    {
        if (healthPlayerMove <= 0)
        {
            PlayerDeath();
        }

        if (npcToWinPlayerMove <= 0)
        {
            npcToWinPlayer += 10;
            npcToWinPlayerMove = npcToWinPlayer;
            levelPlayerMove++;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Pickabele")
        {
            PickUpSoundPlayer.Play();
        }
    }

    public void TakeDamagePlayer(int damage)
    {
        healthPlayerMove -= damage;
        takeDamageSoundPlayer.Play();
    }

    public void PlayerDeath()
    {
        dethSoundPlayer.Play();

        SceneManager.LoadScene(1);

        if (Time.timeScale == 0)
        {
            Time.timeScale = 1;
        }
    }
}
