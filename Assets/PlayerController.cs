using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    private Animator animator;

    public float movespeed = 2f;
    public float jumpForce = 3f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        float moveInput = Input.GetAxis("Horizontal");

        rb.linearVelocity = new Vector2(moveInput * movespeed, rb.linearVelocity.y);

        animator.SetFloat("xVel", Mathf.Abs(moveInput));

        if (moveInput < -0.01f)
        {
            sprite.flipX = true;
            animator.SetBool("isRuning", true);
            animator.SetBool("isIdle", false);
        }
        else if (moveInput > 0.01f)
        {
            sprite.flipX = false;
            animator.SetBool("isRuning", true);
            animator.SetBool("isIdle", false);
        }
        else
        {
            animator.SetBool("isRuning", false);
            animator.SetBool("isIdle", true);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }
    }
}
