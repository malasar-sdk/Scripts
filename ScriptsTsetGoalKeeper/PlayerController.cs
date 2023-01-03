using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour, IDragHandler
{
    [SerializeField]
    private Animator anim;

    [SerializeField]
    private GameObject player;

    [SerializeField]
    private float speedPlayer;

    private SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        _spriteRenderer = player.GetComponent<SpriteRenderer>();
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (Mathf.Abs(eventData.delta.x) > Mathf.Abs(eventData.delta.y))
        {
            if (eventData.delta.x > 0 && player.transform.position.x < 8)
            {
                //anim.SetBool("IsWalkLeft", false);
                //anim.SetBool("IsWalkRight", true);

                _spriteRenderer.transform.position += Vector3.right * 0.1f * speedPlayer;
            }
            else if (eventData.delta.x < 0 && player.transform.position.x > -8)
            {
                //anim.SetBool("IsWalkRight", false);
                //anim.SetBool("IsWalkLeft", true);

                _spriteRenderer.transform.position += Vector3.left * 0.1f * speedPlayer;
            }
            else
            {
                //anim.SetBool("IsWalkRight", false);
                //anim.SetBool("IsWalkLeft", false);
            }
        }
    }
}
