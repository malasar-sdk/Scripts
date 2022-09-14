using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(CapsuleCollider))]
public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private Rigidbody rb;

    [SerializeField]
    private FixedJoystick joystick;

    [SerializeField]
    private Animator animator;

    [SerializeField]
    private float speedMove;

    void Update()
    {
        rb.velocity = new Vector3(joystick.Horizontal * speedMove, rb.velocity.y, joystick.Vertical * speedMove);

        if (joystick.Horizontal != 0 || joystick.Vertical != 0)
        {
            transform.rotation = Quaternion.LookRotation(rb.velocity);
            if (PlayerAtack.attacking == false)
            {
                animator.SetBool("IsMoving", true);
            }
        }
        else
        {
            if (PlayerAtack.attacking == false)
            {
                animator.SetBool("IsMoving", false);
            }
        }
    }
}
