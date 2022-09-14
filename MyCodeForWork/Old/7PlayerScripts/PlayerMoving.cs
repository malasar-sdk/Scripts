using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMoving : MonoBehaviour
{
    public Animator animator;
    public CharacterController controller;
    public NavMeshAgent agent;

    private float speedPlayerCurrent;

    [SerializeField]
    public float speedPlayerNormal;
    [SerializeField]
    public float speedPlayerLow;
    [SerializeField]
    public float jumpPower;
    [SerializeField]
    public float rotationSpeedPlayer;

    float rotateVelocity;

    private float gravityForce;
    private Vector3 moveVector;
    private Vector3 playerDirection;

    public Vector3 targetToWatchOn;
    public GameObject PlayerToRotate;

    private bool atackPosition = false;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();

        speedPlayerCurrent = speedPlayerNormal;
    }

    void Update()
    {
        PlayerMove();
        GamingGravity();
    }

    private void PlayerMove()
    {
        if (controller.isGrounded)
        {
            animator.SetBool("isJump", false);
            animator.SetBool("isFalling", false);

            moveVector = Vector3.zero;
            moveVector.x = Input.GetAxis("Vertical") * speedPlayerCurrent;
            moveVector.z = -Input.GetAxis("Horizontal") * speedPlayerCurrent;

            playerDirection = Vector3.zero;

            Vector3 rayVector = new Vector3(Input.mousePosition.x, 0, Input.mousePosition.y);
            Vector3 playerVector = new Vector3(transform.position.x, 0, transform.position.y);
            playerDirection = rayVector - playerVector;

            if (moveVector.x != 0 || moveVector.z != 0) animator.SetBool("isMoving", true);
            else animator.SetBool("isMoving", false);

            if (atackPosition == false)
            {
                if (Vector3.Angle(Vector3.forward, moveVector) > 1f || Vector3.Angle(Vector3.forward, moveVector) == 0)
                {
                    Vector3 directToMove = Vector3.RotateTowards(transform.forward, moveVector, rotationSpeedPlayer, 0.0f);
                    transform.rotation = Quaternion.LookRotation(directToMove);
                }
            }
            else
            {
                RaycastHit hit;
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(ray, out hit))
                {
                    MousePosUpdate(hit);
                }
            }

            if (Input.GetKeyDown(KeyCode.LeftShift) && atackPosition == false)
            {
                speedPlayerCurrent = speedPlayerLow;
                atackPosition = true;
            }
            else if (Input.GetKeyDown(KeyCode.LeftShift) && atackPosition == true)
            {
                atackPosition = false;
                speedPlayerCurrent = speedPlayerNormal;
            }
        }
        else
        {
            if (gravityForce < -3f) animator.SetBool("isMoving", true);
        }

        moveVector.y = gravityForce;

        controller.Move(moveVector * Time.deltaTime);
    }

    private void GamingGravity()
    {
        if (!controller.isGrounded) gravityForce -= 20f * Time.deltaTime;
        else gravityForce = -1f;

        if (Input.GetKeyDown(KeyCode.Space) && controller.isGrounded)
        {
            gravityForce = jumpPower;
            animator.SetBool("isJump", true);
        }
    }

    private void MousePosUpdate(RaycastHit hit)
    {
        if (hit.transform.tag == "Ground")
        {
            targetToWatchOn = hit.point;

            Quaternion transformRotation = Quaternion.LookRotation(targetToWatchOn - this.transform.position, Vector3.up);
            PlayerToRotate.transform.rotation = Quaternion.Slerp(transformRotation, PlayerToRotate.transform.rotation, 0.9f);
        }
    }
}
