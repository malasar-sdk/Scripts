using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed = 5f;
    public float gravity = -10;
    public float groundDistance = 0.1f;
    public bool isGrounded;
    public float jumpHeiger = 3f;
    public float runing = 10f;

    public GameObject menu;

    Vector3 velocity;
    Vector3 move;

    public Transform groundChek;
    public LayerMask ground;

    public AudioSource jumpSoundPlayer;
    public AudioSource walkSoundPlayer;

    CharacterController Character;

    void Start()
    {
        Character = GetComponent<CharacterController>();
    }

    void Update()
    {
        isGrounded = Physics.CheckSphere(groundChek.position, groundDistance, ground);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        if (!isGrounded)
        {
            velocity.y += gravity * Time.deltaTime;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        move = transform.right * x + transform.forward * z;

        move = transform.TransformDirection(move);

        if (Input.GetButtonDown("Horizontal") || Input.GetButtonDown("Vertical"))
        {
            walkSoundPlayer.Play();
        }
        else if (Input.GetButtonUp("Horizontal") || Input.GetButtonUp("Vertical"))
        {
            walkSoundPlayer.Stop();
        }

        if (Input.GetKey(KeyCode.LeftShift) && isGrounded == true)
        {
            Character.Move(move * runing * Time.deltaTime);
        }
        else
        {
            Character.Move(move * speed * Time.deltaTime);
        }

        Character.Move(velocity * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isGrounded == true)
        {
            velocity.y = Mathf.Sqrt(jumpHeiger * -2f * gravity);
            walkSoundPlayer.Stop();
            jumpSoundPlayer.Play();
        }
    }
}
