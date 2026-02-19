using UnityEngine;

public class NightBourne : MonoBehaviour
{
    Rigidbody2D rb;
    SpriteRenderer sr;
    Animator animator;
    GameObject player;

    bool isPlayerInRange = false;
    bool isPlayerClose = false;
    bool isAttacking = false;
    bool isRunning = false;
    bool isFacingRight = true;

    public float moveSpeed = 2f;
    public float chaseRange = 5f;
    public float inAttackRange = 1.2f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        player = GameObject.FindWithTag("player");
    }

    // Update is called once per frame
    void Update()
    {
        DetectPlayer();
        flipDirection();
    }

    void DetectPlayer()
    {
        if (player == null) return;
        float distanceToPlayer = Vector2.Distance(transform.position, player.transform.position);
        if (distanceToPlayer <= inAttackRange)
        {
            isPlayerInRange = true;
            AttackPlayer();
        }
        else
        {
            isPlayerInRange = false;
        }
    }

    void AttackPlayer()
    {
        if (isPlayerInRange && !isAttacking)
        {
            isAttacking = true;
            rb.linearVelocity = Vector2.zero;
            animator.SetTrigger("attack");
        }
    }

    void flipDirection()
    {
        // if player is to the right, face right
        if (player.transform.position.x > transform.position.x && !isFacingRight)
        {
            sr.flipX = true;
        }
        else if (player.transform.position.x < transform.position.x && isFacingRight)
        {
            sr.flipX = false;
        }
    }
}
