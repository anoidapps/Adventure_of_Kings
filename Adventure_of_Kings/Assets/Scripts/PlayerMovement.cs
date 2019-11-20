using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed; // Speed of player
    private Rigidbody2D playerRigidbody; // rigidbody of player
    private Vector3 change; // Player position change

    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        playerRigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        change = Vector3.zero;
        change.x = Input.GetAxisRaw("Horizontal");
        change.y = Input.GetAxisRaw("Vertical");
        // Debug.Log(change);
        UpdateAnimationAndMove();

    }

    void UpdateAnimationAndMove ()
    {
        if (change != Vector3.zero)
        {
            MoveCharacter();
            animator.SetFloat("moveX", change.x);
            animator.SetFloat("moveY", change.y);
            animator.SetBool("moving", true);
        }

        else
        {
            animator.SetBool("moving", false);
        }
    }

    void MoveCharacter ()
    {
        playerRigidbody.MovePosition(
            transform.position + change * speed * Time.deltaTime
            );
    }
}
