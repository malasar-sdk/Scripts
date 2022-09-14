using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent (typeof (NavMeshAgent))]
public class Enemy : MonoBehaviour
{
    public GameObject player;
    NavMeshAgent agent;

    public GameObject medKitSpawn;
    public GameObject ammoKitSpawn;
    public GameObject coinSpawn;

    [SerializeField] public Transform placePickable;


    public float dist;
    public float radius = 20;

    public int health = 3;

    public AudioSource takeDamageSound;
    public AudioSource damageSound;
    public AudioSource dethSound;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }
    
    void Update()
    {
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }

        dist = Vector3.Distance(player.transform.position, transform.position);

        if (dist > radius)
        {
            agent.enabled = false;
        }

        if (dist < radius)
        {
            agent.enabled = true;
            agent.SetDestination(player.transform.position);
        }

        if (health <= 0)
        {
            dethSound.Play();

            int ran = Random.Range(1, 3);
            switch (ran)
            {
                case 1:
                    GameObject spawn1 = Instantiate(coinSpawn);
                    spawn1.transform.localPosition = placePickable.position;
                    break;
                case 2:
                    GameObject spawn2 = Instantiate(ammoKitSpawn);
                    spawn2.transform.localPosition = placePickable.position;
                    break;
                case 3:
                    GameObject spawn3 = Instantiate(coinSpawn);
                    spawn3.transform.localPosition = placePickable.position;
                    break;
            }

            PlayerSystematic.npcToWinPlayerMove--;

            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.gameObject.GetComponent<PlayerSystematic>().TakeDamagePlayer(20);
            Destroy(gameObject);
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        takeDamageSound.Play();
    }
}
