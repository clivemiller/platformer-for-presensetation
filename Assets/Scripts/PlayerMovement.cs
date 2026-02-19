using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 5f;
    Rigidbody2D rb;
    Animator animator;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        HandleMove();
;       HandleJump();
    }

    void HandleMove()
    {
        float horizontal = 0f;

        if (Keyboard.current.aKey.isPressed)
        {
            horizontal = -1f;
            animator.SetTrigger("left");
        }
        else if (Keyboard.current.dKey.isPressed)
        {
            horizontal = 1f;
            animator.SetTrigger("right");
        }

        rb.linearVelocity = new Vector2(horizontal * moveSpeed, rb.linearVelocity.y);

        animator.SetBool("isIdle", rb.linearVelocity.normalized == Vector2.zero);
    }

    void HandleJump()
    {
        animator.SetBool("isJumping", rb.linearVelocity.y != 0f);

        if (Keyboard.current.spaceKey.wasPressedThisFrame && rb.linearVelocity.y == 0f)
        {
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        } 
        else if (Keyboard.current.spaceKey.wasReleasedThisFrame && rb.linearVelocity.y == 0f)
        {
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        }


    }
}
